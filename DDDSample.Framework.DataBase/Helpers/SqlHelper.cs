using DDDSample.Domain.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Dynamic;
using DDDSample.Domain.Core.Entities;
using System.Linq;

namespace DDDSample.Framework.DataBase.Helpers
{
    public class SqlHelper : ISqlHelper
    {
        private SampleDBContext _context;
        public SqlHelper(SampleDBContext context)
        {
            _context = context;
        }

        private static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            // ExpandoObject da suporte a IDictionary então podemos estendê-lo assim:
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }

        public void Execute(string commandtext)
        {
            _context.Database.ExecuteSqlRaw(commandtext, null);
            //_context.Database.ExecuteSqlCommand(commandtext);
        }

        public dynamic Get<TEntity>(Guid id, string[] fields) where TEntity : EntidadeBase
        {
            var type = typeof(TEntity);
            var properties = type.GetProperties();
            
            foreach (var field in fields)
            {
                var achou = properties.Where(a => a.Name == field).FirstOrDefault();
                if (achou == null)
                {
                    throw new Exception($"Propriedade {field} não existe no modelo {type.Name}");
                }
            }

            var tableName = type.Name + 's'; //colocando o nome da tabela no plural;

            StringBuilder sql = new StringBuilder();
            
            var listFields = string.Join(",", fields.Select(s => $"{s}").ToArray());
            sql.Append($"Select {listFields} From {tableName} where Id = '{id.ToString()}'");
            var result = this.Query(sql.ToString());
            return result.FirstOrDefault();
        }

        public IEnumerable<dynamic> Query(string sql)
        {
            
            var rows = _context.Database.GetDbConnection().Query<object>(sql);

            var result = new List<dynamic>();
            foreach (IDictionary<string, object> row in rows)
            {
                dynamic expando = new ExpandoObject();
                foreach (var pair in row)
                {
                    AddProperty(expando, pair.Key, pair.Value);
                }
                result.Add(expando);
            }
            return result;

        }
    }
}

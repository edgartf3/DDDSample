using DDDSample.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace DDDSample.Domain.Core.Helpers
{
    public class QueryHelper
    {
        private static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            // ExpandoObject da suporte a IDictionary então podemos estendê-lo assim:
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }

        public static dynamic Get<TEntity>(Guid id, string[] fields) where TEntity : EntidadeBase
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




            var sql = new object[] { false, "Banana" };
            dynamic expando = new ExpandoObject();
            var i = 0;
            foreach (var field in fields)
            {
                AddProperty(expando, field, sql[i]);
                i = i +1;
            }

            return expando;
        }

        public static T Get<T>(dynamic result, string property)
        {
            return result.GetType().GetProperty(property).GetValue(result, null);
        }
    }
}

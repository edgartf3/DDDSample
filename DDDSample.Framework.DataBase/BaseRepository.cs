using DDDSample.Domain.Core.Attributes;
using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDSample.Framework.DataBase
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity> 
        where TEntity : EntidadeBase
        where TContext: DbContext
    {
        protected TContext _context;
        protected DbSet<TEntity> _dbSet;
        public BaseRepository(TContext dbContext)
        {
            _context = dbContext;
            _dbSet = dbContext.Set<TEntity>();

        }

        public void Create(TEntity model)
        {
            this.ApplyConfig(model);
            model.CriadoEm = DateTime.Now;
            _dbSet.Add(model);            
        }

        public void Delete(TEntity model)
        {
            this.ApplyConfig(model);
            _dbSet.Remove(model);            
        }

        public void Delete(Guid id)
        {
            var model = this.Get(id);
            this.ApplyConfig(model);
            _dbSet.Remove(model);
        }

        public TEntity Get(Guid id)
        {
            //Queryable não é executado no banco de dados imediatamente, entrada.
            var query = _dbSet.AsQueryable();

            //EntityType Obtém o tipo de entidade para o nome fornecido, definindo o nome da navegação 
            //e o tipo de entidade. Retorna nulo se nenhum tipo de entidade correspondente for encontrado.

            //AsNoTracking usar semper que for buscar algo - leitura rapida no banco de dados.
            foreach (var property in _context.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name).AsNoTracking();

            return query.Where(a => a.Id == id).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()

        {
            //Queryable não é executado no banco de dados imediatamente, entrada.
            var query = _dbSet.AsQueryable();

            //EntityType Obtém o tipo de entidade para o nome fornecido, definindo o nome da navegação 
            //e o tipo de entidade. Retorna nulo se nenhum tipo de entidade correspondente for encontrado.

            foreach (var property in _context.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                 query = query.Include(property.Name).AsNoTracking();

            return query;
        }

        public static object CheckUpdateObject(object originalObj, object updateObj)
        {
            foreach (var property in updateObj.GetType().GetProperties())
            {
                if (property.GetValue(updateObj, null) == null)
                {
                    property.SetValue(updateObj, originalObj.GetType().GetProperty(property.Name)
                    .GetValue(originalObj, null));
                }
            }
            return updateObj;
        }

        public void Update(TEntity model)
        {
            this.ApplyConfig(model);
            _dbSet.Update(model);
           
        }

        private void ApplyConfig(TEntity model)
        {
            var properties = model.GetType().GetProperties();
            foreach (var prop in properties)
            {
                //if (prop.GetGetMethod().IsVirtual)
                //{
                //    prop.SetValue(model, null);
                //}

               
                var attributies = prop.GetCustomAttributes(true);
                foreach (var attribute in attributies)
                {
                    if (attribute is NotPersist)
                    {
                        prop.SetValue(model, null);
                    }
                }
            }
            
        }

        public void ExecuteSql(string sql)
        {
           // _context.Database.ExecuteSqlCommand(sql);
        }

        public IEnumerable<dynamic> Query(string sql)
        {
            return _dbSet.FromSqlRaw(sql).ToList();
        }
    }
}

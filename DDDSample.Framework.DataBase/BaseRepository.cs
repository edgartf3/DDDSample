using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Venda.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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
            model.CriadoEm = DateTime.Now;
            _dbSet.Add(model);
            _context.SaveChangesAsync().Wait();
        }

        public void Delete(TEntity model)
        {
            _dbSet.Remove(model);
            _context.SaveChangesAsync().Wait();
        }

        public void Delete(Guid id)
        {
            _dbSet.Remove(this.Get(id));
            _context.SaveChangesAsync().Wait();
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
            _dbSet.Update(model);
           
            //// Here model is model return from form on post
            //var oldobj = _dbSet.Where(x => x.Id == model.Id).SingleOrDefault();

            //// Newly Inserted Code
            //var UpdatedObj = CheckUpdateObject(oldobj, model);

            //_context.Entry(oldobj).CurrentValues.SetValues(UpdatedObj);
            _context.SaveChangesAsync().Wait();
        }
    }
}

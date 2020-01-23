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
            _dbSet.Add(model);
            _context.SaveChanges();            
        }

        public void Delete(TEntity model)
        {
            _dbSet.Remove(model);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _dbSet.Remove(this.Get(id));
            _context.SaveChanges();
        }

        public TEntity Get(Guid id)
        {
            //Queryable não é executado no banco de dados imediatamente, entrada.
            var query = _dbSet.AsQueryable();

            //EntityType Obtém o tipo de entidade para o nome fornecido, definindo o nome da navegação 
            //e o tipo de entidade. Retorna nulo se nenhum tipo de entidade correspondente for encontrado.

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

        public void Update(TEntity model)
        {
            throw new NotImplementedException();
        }
    }
}

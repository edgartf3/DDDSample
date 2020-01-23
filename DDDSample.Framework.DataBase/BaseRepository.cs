using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Venda.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSample.Framework.DataBase
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntidadeBase
    {
        private SampleDBContext _context;
        protected DbSet<T> _dbSet;
        public BaseRepository(SampleDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }
        public void Create(T model)
        {
            _dbSet.Add(model);
            _context.SaveChanges();            
        }

        public void Delete(T model)
        {
            _dbSet.Remove(model);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _dbSet.Remove(this.Get(id));
            _context.SaveChanges();
        }

        public T Get(Guid id)
        {
            //Queryable não é executado no banco de dados imediatamente, entrada.
            var query = _dbSet.AsQueryable();

            //EntityType Obtém o tipo de entidade para o nome fornecido, definindo o nome da navegação 
            //e o tipo de entidade. Retorna nulo se nenhum tipo de entidade correspondente for encontrado.

            foreach (var property in _context.Model.FindEntityType(typeof(T)).GetNavigations())
                query = query.Include(property.Name)
                    
                    .AsNoTracking();

            return query.Where(a => a.Id == id).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()

        {
            //Queryable não é executado no banco de dados imediatamente, entrada.
            var query = _dbSet.AsQueryable();

            //EntityType Obtém o tipo de entidade para o nome fornecido, definindo o nome da navegação 
            //e o tipo de entidade. Retorna nulo se nenhum tipo de entidade correspondente for encontrado.

            foreach (var property in _context.Model.FindEntityType(typeof(T)).GetNavigations())
                 query = query.Include(property.Name).AsNoTracking();

            return query;
        }

        public void Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}

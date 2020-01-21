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
            return _dbSet.Where(a => a.Id == id).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToArray();
        }

        public void Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}

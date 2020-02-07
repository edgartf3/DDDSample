using DDDSample.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Core.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : EntidadeBase
    {
        void Create(TEntity model);
        void Update(TEntity model);
        void Delete(TEntity model);
        void Delete(Guid id);
        TEntity Get(Guid id);        
        IEnumerable<TEntity> GetAll();  
        
    }
}

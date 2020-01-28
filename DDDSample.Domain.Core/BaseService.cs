using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Core
{
    public class BaseService<T> : IBaseService<T> where T : EntidadeBase
    {
        protected IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void Create(T model)
        {
            this._baseRepository.Create(model);
        }

        public void Delete(T model)
        {
            this._baseRepository.Delete(model);
        }

        public void Delete(Guid id)
        {
            this._baseRepository.Delete(id);
        }

        public T Get(Guid id)
        {
            return this._baseRepository.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this._baseRepository.GetAll();
        }

        public void Update(T model)
        {
            //
            this._baseRepository.Update(model);
        }
    }
}

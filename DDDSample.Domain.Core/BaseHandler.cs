using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Core
{
    public class BaseHandler<T> : IBaseHandler<T> where T : EntidadeBase
    {
        protected IBaseRepository<T> _baseRepository;
        public BaseHandler(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void Create(T model)
        {
            var sql = "Update Fabricantes Set Descricao = 'Raimundo 7' where Id = '26CA2C84-9C2E-4B0D-5165-08D7B0CEB838'";
            _baseRepository.ExecuteSql(sql);
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

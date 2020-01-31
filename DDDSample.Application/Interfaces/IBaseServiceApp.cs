using DDDSample.Application.ViewsModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Application.Interfaces
{
    public interface IBaseServiceApp<T> where T: EntidadeViewModelBase
    {
        void Create(T model);
        void Update(T model);
        void Delete(T model);
        void Delete(Guid id);
        T Get(Guid id);
        IEnumerable<T> GetAll();
    }
}

using AutoMapper;
using DDDSample.Application.Interfaces;
using DDDSample.Application.ViewsModels;
using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Application.AppServices
{
    public class BaseServiceApp<TViewModel, TBaseModel> : IBaseServiceApp<TViewModel> 
        where TViewModel : EntidadeViewModelBase
        where TBaseModel : EntidadeBase
    {
        private IBaseService<TBaseModel> _service;

        public BaseServiceApp(IBaseService<TBaseModel> service)
        {
            _service = service;
        }

        public void Create(TViewModel model)
        {
            var entity = Mapper.Map<TViewModel, TBaseModel>(model);
            _service.Create(entity);
        }

        public void Delete(TViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public TViewModel Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}

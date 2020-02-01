using AutoMapper;
using DDDSample.Application.Core.Interfaces;
using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace DDDSample.Application.Core.AppServices
{
    public class BaseServiceApp<TViewModel, TBaseModel> : IBaseServiceApp<TViewModel>
        where TViewModel : EntidadeBase
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
            var entity = Mapper.Map<TViewModel, TBaseModel>(model);
            _service.Delete(entity);
        }

        public void Delete(Guid id)
        {
            _service.Delete(id);
        }

        public TViewModel Get(Guid id)
        {
            var result = _service.Get(id);
            return Mapper.Map<TBaseModel, TViewModel>(result);
        }

        public IEnumerable<TViewModel> GetAll()
        {
            var result = _service.GetAll();
            return Mapper.Map<IEnumerable<TBaseModel>, IEnumerable<TViewModel>>(result);
        }

        public void Update(TViewModel model)
        {
            var entity = Mapper.Map<TViewModel, TBaseModel>(model);
            _service.Update(entity);
        }
    }
}

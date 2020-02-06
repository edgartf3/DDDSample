using DDDSample.Application.Core.AppServices;
using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Entities;
using System;

namespace DDDSample.Application.Services
{
    public class VendaServiceApp : BaseServiceApp<Venda, Venda>
    {
        private IInjector _injector;
        public VendaServiceApp(IBaseService<Venda> service, IInjector injector) : base(service)
        {
            _injector = injector;
        }

        //não acho correto carregar a venda inteira para adicionar um item
        public void AddItem(Guid VendaId, Guid produtoId, double quantidade)
        {

            var venda = this._service.Get(VendaId);
            venda.AdicionarItem(produtoId, quantidade, _injector);
            _service.Update(venda);
        }
    }
}

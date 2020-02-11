using DDDSample.Application.Core;
using DDDSample.Application.Services.Interfaces;
using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Entities;
using DDDSample.Domain.Interfaces.Services;
using DDDSample.Framework.DataBase.UoW;
using DDDSample.Framework.DataBase.UoW.Interfaces;
using System;

namespace DDDSample.Application.Services
{
    public class VendaService : BaseService<Venda, Venda>, IVendaService
    {
        private IVendaHandler _vendaHandler;       
        
        public VendaService(IVendaHandler handler, IUnitOfWork uow) : base(handler, uow)
        {
            _vendaHandler = handler;            
        }
        
        public void AdicionarItem(Guid VendaId, Guid produtoId, double quantidade)
        {
            _vendaHandler.AdicionarItem(VendaId, produtoId, quantidade);
            _uow.Commit();
        }

        public void DarDesconto(Guid vendaId, double desconto)
        {
            _vendaHandler.DarDesconto(vendaId, desconto);
            _uow.Commit();
        }

        public Venda NovaVenda()
        {
            var result = _vendaHandler.NovaVenda();
            _uow.Commit();
            return result;
        }

        public void RemoverItem(Guid vendaId, Guid itemId)
        {
            _vendaHandler.RemoverItem(vendaId, itemId);
            _uow.Commit();
        }
    }
}

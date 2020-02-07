using DDDSample.Application.Core;
using DDDSample.Application.Services.Interfaces;
using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Entities;
using DDDSample.Domain.Interfaces.Services;
using System;

namespace DDDSample.Application.Services
{
    public class VendaService : BaseService<Venda, Venda>, IVendaService
    {
        private IVendaHandler _vendaHandler;       
        
        public VendaService(IVendaHandler handler) : base(handler)
        {
            _vendaHandler = handler;            
        }
        
        public void AdicionarItem(Guid VendaId, Guid produtoId, double quantidade)
        {
            _vendaHandler.AdicionarItem(VendaId, produtoId, quantidade);            
        }

        public void DarDesconto(Guid vendaId, double desconto)
        {
            _vendaHandler.DarDesconto(vendaId, desconto);
        }

        public Venda NovaVenda()
        {
            return _vendaHandler.NovaVenda();
        }

        public void RemoverItem(Guid vendaId, Guid itemId)
        {
            _vendaHandler.RemoverItem(vendaId, itemId);
        }
    }
}

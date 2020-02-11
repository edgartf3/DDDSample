using DDDSample.Application.Core;
using DDDSample.Application.ViewsModels;
using DDDSample.Domain.Entities;
using System;

namespace DDDSample.Application.Services.Interfaces
{
    public interface IVendaService : IBaseService<VendaViewModel>
    {
        VendaViewModel NovaVenda();
        void AdicionarItem(Guid vendaId, Guid produtoId, double quantidade);
        void RemoverItem(Guid vendaId, Guid itemId);
        void DarDesconto(Guid vendaId, double desconto);
    }
}

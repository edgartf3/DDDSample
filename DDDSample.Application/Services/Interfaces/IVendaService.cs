using DDDSample.Application.Core;
using DDDSample.Domain.Entities;
using System;

namespace DDDSample.Application.Services.Interfaces
{
    public interface IVendaService : IBaseService<Venda>
    {
        Venda NovaVenda();
        void AdicionarItem(Guid vendaId, Guid produtoId, double quantidade);
        void RemoverItem(Guid vendaId, Guid itemId);
        void DarDesconto(Guid vendaId, double desconto);
    }
}

using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Interfaces.Services
{
    public interface IVendaHandler: IBaseHandler<Venda>
    {
        Venda NovaVenda();
        void AdicionarItem(Guid vendaId, Guid produtoId, double quantidade);
        void RemoverItem(Guid vendaId, Guid itemId);
        void DarDesconto(Guid vendaId, double desconto);
    }
}

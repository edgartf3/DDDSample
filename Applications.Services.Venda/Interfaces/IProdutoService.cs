using DDDSample.Domain.Venda.Entities;
using DDDSample.Domain.Venda.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Services.Venda.Interfaces
{
    public interface IProdutoService
    {
        IEnumerable<IProduto> Get();
    }
}

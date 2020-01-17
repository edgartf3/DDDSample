using DDDSample.Domain.Venda.Entities;
using DDDSample.Domain.Venda.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Framework.DataBase.Interfaces
{
    public interface IProdutoRepository
    {
        void Criar(IProduto produto);
        void Excluir(IProduto produto);

        IEnumerable<IProduto> Get();

        Produto GetById(Guid produtoId);

        void Alterar(IProduto produto);
        
    }
}

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
    }
}

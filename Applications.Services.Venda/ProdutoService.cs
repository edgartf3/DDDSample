using DDDSample.Domain.Venda.Interfaces;
using DDDSample.Framework.DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.Services.Venda
{
    public class ProdutoService
    {
        private IProduto _produto;
        private IProdutoRepository _produtoRepository;
        public ProdutoService(IProduto produto, IProdutoRepository produtoRepository)
        {
            this._produto = produto;
            this._produtoRepository = produtoRepository;
        }

        public void Criar()
        {
            if (!this._produto.IsValid()) throw new Exception("Produto Inválido");
            _produtoRepository.Criar(_produto);
        }
        
    }
}

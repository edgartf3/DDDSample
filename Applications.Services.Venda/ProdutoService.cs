using DDDSample.Domain.Venda.Entities;
using DDDSample.Domain.Venda.Interfaces;
using DDDSample.Framework.DataBase.Interfaces;
using DDDSample.Services.Venda.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.Services.Venda
{
    public class ProdutoService: IProdutoService
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

        public IEnumerable<IProduto> Get()
        {
            return _produtoRepository.Get();            
        }
    }
}

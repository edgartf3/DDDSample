using DDDSample.Domain.Core.Helpers;
using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Entities;
using DDDSample.Domain.Interfaces.Handlers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace DDDSample.Domain.Handlers
{
    public class ProdutoHandler : IProdutoHandler
    {
        private IBaseRepository<Produto> _produtoRepository;
        private ISqlHelper _sqlHelper;

        public ProdutoHandler(IBaseRepository<Produto> produtoRepository, ISqlHelper sqlHelper)
        {
            _produtoRepository = produtoRepository;
            _sqlHelper = sqlHelper;
        }


        public void Create(Produto produto)
        {

            //1-  perguntar se o fabricante é ativo
            var fabricante = _sqlHelper.Get<Fabricante>(produto.FabricanteId.Value, new string[] { "Ativo", "Descricao" });
            if (fabricante == null)
            {
                throw new Exception("Fabricante não localizado");
            }

            if (!fabricante.Ativo)
            {
                throw new Exception("Fabricante inativo");
            }

            

            //2 - preço deve ser maior que zero
            if (produto.Preco <= 0.00)
            {
                throw new Exception("O preço do produto deve ser maior que zero");
            }


            _produtoRepository.Create(produto);


        }
    }
}

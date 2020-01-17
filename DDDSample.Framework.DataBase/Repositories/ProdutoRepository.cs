using DDDSample.Domain.Venda.Entities;
using DDDSample.Domain.Venda.Interfaces;
using DDDSample.Framework.DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Framework.DataBase.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public void Alterar(IProduto produto)
        {
            throw new NotImplementedException();
        }

        public void Criar(IProduto produto)
        {
            throw new NotImplementedException();
        }

        public void Excluir(IProduto produto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduto> Get()
        {
            var result = new List<IProduto>();
            var produto1 = new Produto()
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Now,
                Descricao = "Banana",
                Preco = 2.00
            };

            var produto2 = new Produto()
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Now,
                Descricao = "Maça",
                Preco = 3.00
            };

            var produto3 = new Produto()
            {
                Id = Guid.NewGuid(),
                CriadoEm = DateTime.Now,
                Descricao = "Abacaxi",
                Preco = 2.50
            };

            result.Add(produto1);
            result.Add(produto2);
            result.Add(produto3);

            return result;
        }

        public Produto GetById(Guid produtoId)
        {
            throw new NotImplementedException();
        }
    }
}

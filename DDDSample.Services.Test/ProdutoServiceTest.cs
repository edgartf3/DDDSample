using Applications.Services.Venda;
using DDDSample.Domain.Venda.Entities;
using DDDSample.Framework.DataBase.Repositories;
using NUnit.Framework;

namespace DDDSample.Services.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Criar()
        {
            var produto = new Produto();
            produto.Descricao = "Banana";
            produto.Preco = 1.23;
            var rep = new ProdutoRepository();
            var produtoService = new ProdutoService(produto, rep);
            produtoService.Criar();
            Assert.Pass();
        }
    }
}
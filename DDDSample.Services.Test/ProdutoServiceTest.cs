using DDDSample.Domain.Vendas.Entities;
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

            Assert.Pass();
        }
    }
}
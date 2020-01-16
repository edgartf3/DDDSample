using DDDSample.Domain.Venda.Entities;
using NUnit.Framework;

namespace DDDSample.Domain.Venda.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsValid()
        {
            var produto = new Produto();
            produto.Descricao = "Descricao";
            produto.Preco = 1.78;

            Assert.IsTrue(produto.IsValid());
        }

        [Test]
        public void IsNotValid()
        {
            var produto = new Produto();
            produto.Descricao = "Descricao";
            try
            {
                produto.Preco = -1.78;
                Assert.IsTrue(false, "Não deu erro ao setar preço negativo");
            }
            catch
            {

            }
            

            Assert.IsFalse(produto.IsValid());
        }
    }
}
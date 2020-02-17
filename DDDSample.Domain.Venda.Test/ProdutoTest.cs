using DDDSample.Domain.Entities;
using NUnit.Framework;

namespace DDDSample.Domain.Vendas.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Service()
        {
            // repository = new BaseRepository<Produto>();
            //var service = new BaseService<Produto>(repository);
            //service.Create(new Produto());
        }

        [Test]
        public void IsValid()
        {            
            var produto = new Produto();
            produto.Descricao = "Descricao";
            produto.Preco = 1.78;

            Assert.IsTrue(produto.IsValid());
        }

    }
}
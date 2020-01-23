using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Venda.Entities;
using DDDSample.Framework.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Data.Entity;

namespace DDDSample.Repositories.Test
{
    public class BaseRepositoryTest
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=DDDSampleTest;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; MultipleActiveResultSets=true";
        private SampleDBContext _context;
        private Guid produtoId;
        private BaseRepository<Produto, SampleDBContext> repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<SampleDBContext>()
                .UseSqlServer(connectionString)
                .Options;


            _context = new SampleDBContext(options);
            _context.Database.Migrate();

            repository = new BaseRepository<Produto, SampleDBContext>(_context);

        }

        [Test]
        [Order(0)]
        public void Incluir()
        {
            

            var produto = new Produto();
            produto.Descricao = "Laranja";
            produto.Preco = 1.89;

            repository.Create(produto);

            var x = repository.Get(produto.Id);
            Assert.IsNotNull(x);
            Assert.AreEqual("Laranja", x.Descricao);
            Assert.AreEqual(produto.Id, x.Id);
            produtoId = x.Id;
            Assert.Pass();
        }      
        
        [Test]
        [Order(1)]
        public void Update()
        {            
            var produto = repository.Get(produtoId);
            produto.Descricao = "Maçã";
            produto.Preco = 4.5;
            repository.Update(produto);

            var x = repository.Get(produtoId);
            Assert.IsNotNull(x);
            Assert.AreEqual("Maçã", x.Descricao);
            Assert.AreEqual(4.5, x.Preco);

        }

        [Test]
        [Order(2)]
        public void Delete()
        {
            //repository.Delete(produtoId);
            //var x = repository.Get(produtoId);            
            //Assert.IsNull(x);

        }
    }
}
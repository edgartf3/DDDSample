<<<<<<< HEAD
using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Venda.Entities;
using DDDSample.Framework.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Data.Entity;
=======
using DDDSample.Domain.Venda.Entities;
using DDDSample.Framework.DataBase;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
>>>>>>> 397fc590adfb3a2a5a095a83686192d24a075271

namespace DDDSample.Repositories.Test
{
    [Order(1)]
    public class BaseRepositoryTest
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=DDDSampleTest;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; MultipleActiveResultSets=true";
        private SampleDBContext _context;
        private Guid produtoId;
        private BaseRepository<Produto, SampleDBContext> repository;

<<<<<<< HEAD
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<SampleDBContext>()
                .UseSqlServer(connectionString)
                .Options;


            _context = new SampleDBContext(options);
            _context.Database.Migrate();

            repository = new BaseRepository<Produto, SampleDBContext>(_context);
=======
        private BaseRepository<Fabricante, SampleDBContext> FabricanteRepository;

        [SetUp]
        public void Setup()
        {
            _context = TestHelper.GetContexto();

            repository = TestHelper.CriarRepositorio<Produto>(_context);
            FabricanteRepository = TestHelper.CriarRepositorio<Fabricante>(_context);
>>>>>>> 397fc590adfb3a2a5a095a83686192d24a075271

        }

        [Test]
        [Order(0)]
        public void Incluir()
        {
<<<<<<< HEAD
            
=======
                       
>>>>>>> 397fc590adfb3a2a5a095a83686192d24a075271

            var produto = new Produto();
            produto.Descricao = "Laranja";
            produto.Preco = 1.89;
<<<<<<< HEAD
=======
            produto.Fabricante = FabricanteRepository.Get(Guid.Parse("B09A87F1-838F-4070-87DF-049A3AE19A0C"));
>>>>>>> 397fc590adfb3a2a5a095a83686192d24a075271

            repository.Create(produto);

            var x = repository.Get(produto.Id);
            Assert.IsNotNull(x);
            Assert.AreEqual("Laranja", x.Descricao);
            Assert.AreEqual(produto.Id, x.Id);
            produtoId = x.Id;
<<<<<<< HEAD
            Assert.Pass();
=======
>>>>>>> 397fc590adfb3a2a5a095a83686192d24a075271
        }      
        
        [Test]
        [Order(1)]
        public void Update()
        {            
<<<<<<< HEAD
            var produto = repository.Get(produtoId);
            produto.Descricao = "Ma��";
            produto.Preco = 4.5;
            repository.Update(produto);
=======
            var produto = repository.Get(Guid.Parse("D875D491-1116-4A0E-A8BB-65CBBB53BF24"));
            produto.Descricao = "Mouse";
            produto.Preco = 67.90;
            repository.Update(produto);
           
>>>>>>> 397fc590adfb3a2a5a095a83686192d24a075271

            var x = repository.Get(produtoId);
            Assert.IsNotNull(x);
            Assert.AreEqual("Ma��", x.Descricao);
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
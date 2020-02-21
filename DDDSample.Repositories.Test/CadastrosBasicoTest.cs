using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Entities;
using DDDSample.Domain.Handlers;
using DDDSample.Framework.DataBase;
using DDDSample.Framework.DataBase.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSample.Repositories.Test
{
    [Order(100)]
    class CadastrosBasicoTest
    {

        private SampleDBContext _context;
        private IBaseRepository<Fabricante> _fabricanteRepository;
        private IBaseRepository<RamoAtividade> _ramoRepository;
        private IBaseRepository<Produto> _produtoRepository;

        [SetUp]
        public void Setup()
        {
            _context = TestHelper.GetContexto();
            _fabricanteRepository = TestHelper.CriarRepositorio<Fabricante>(_context);
            _ramoRepository = TestHelper.CriarRepositorio<RamoAtividade>(_context);
            _produtoRepository = TestHelper.CriarRepositorio<Produto>(_context);

        }

        [Test]
        [Order(0)]
        public void Fabricantes_Incluir()
        {
            _fabricanteRepository.Create(new Fabricante("Dell"));
            _fabricanteRepository.Create(new Fabricante("Sansumg"));
            _fabricanteRepository.Create(new Fabricante("LG"));
            _context.SaveChanges();

            var count =_fabricanteRepository.GetAll().Count();
            Assert.AreEqual(3, count);
        }

        [Test]
        [Order(1)]
        public void Fabricantes_Incluir_Guid()
        {
            var id = Guid.Parse("431424A3-5734-412F-8DFC-E6A906F19AD8");
            _fabricanteRepository.Create(new Fabricante("Nestles", id));
            _fabricanteRepository.Create(new Fabricante("Bauduco", Guid.Parse("083AE12D-C6AF-49D0-92F9-A54C89A9C307")));
            var perdigao = new Fabricante("Perdigão", Guid.Parse("B6C120D4-E5FF-48B9-BC1B-438DF2360D63"));            
            _fabricanteRepository.Create(perdigao);
            _context.SaveChanges();

            var count = _fabricanteRepository.GetAll().Count();
            Assert.AreEqual(6, count);

            var fab = _fabricanteRepository.Get(id);
            Assert.AreEqual("Nestles", fab.Descricao);
            Assert.IsTrue(fab.Ativo);

            fab.Ativo = false;
            fab.Descricao = "Nestle";
            _fabricanteRepository.Update(fab);


            var fab2 = _fabricanteRepository.Get(id);
            Assert.AreEqual("Nestle", fab2.Descricao);
            Assert.IsFalse(fab2.Ativo);
            _context.SaveChanges();

        }

        [Test]        
        [Order(2)]
        public void Fabricantes_UniqueKey1()
        {
            var id = Guid.Parse("431424A3-5734-412F-8DFC-E6A906F19AD8");
            var fab = new Fabricante("KBom", id);
            _fabricanteRepository.Create(fab);
                                    
            try
            {
                _context.SaveChanges();
                Assert.IsTrue(false);
            } catch (Exception e)
            {
                Assert.IsTrue(true, e.Message);
            }            
        }

        [Test]
        [Order(3)]
        public void Fabricantes_UniqueKey2()
        {
            
            _fabricanteRepository.Create(new Fabricante("tcl"));
            _context.SaveChanges();

            var count = _fabricanteRepository.GetAll().Count();
            Assert.AreEqual(7, count);
        }

        [Test]
        [Order(4)]
        public void Fabricantes_UniqueKey3()
        {

            _fabricanteRepository.Create(new Fabricante("Nestle"));
            try
            {
                _context.SaveChanges();
                Assert.IsTrue(false, "Conseguiu salvar");
            }
            catch (Exception e)
            {
                Assert.IsTrue(true, e.Message);
            }

        }

        [Test]
        [Order(5)]
        public void Fabricantes_Excluir_Perdigao1()
        {
            var id = Guid.Parse("B6C120D4-E5FF-48B9-BC1B-438DF2360D63");
            
            _fabricanteRepository.Delete(id);
            _context.SaveChanges();

            var fab = _fabricanteRepository.Get(id);
            Assert.IsNull(fab);
        }

        [Test]
        [Order(6)]
        public void Fabricantes_Excluir_Perdigao2()
        {
            var id = Guid.Parse("B6C120D4-E5FF-48B9-BC1B-438DF2360D63");
                      
            try
            {
                _fabricanteRepository.Delete(id);
                _context.SaveChanges();
                Assert.IsTrue(false, "Era para ter dado um erro");
            }
            catch(Exception e)
            {                
                Assert.IsTrue(true, e.Message);
            }
            

            
        }


        [Test]
        [Order(20)]
        public void InserirRamosAtividade()
        {
            _ramoRepository.Create(new RamoAtividade("Shoping"));
            _ramoRepository.Create(new RamoAtividade("Galeria"));
            _ramoRepository.Create(new RamoAtividade("Manutenção"));
            _context.SaveChanges();            
        }

        [Test]
        [Order(30)]
        public void InserirProdutos_Repository()
        {
            var produto = new Produto()
            {
                Descricao = "Mouse",
                FabricanteId = Guid.Parse("431424A3-5734-412F-8DFC-E6A906F19AD8"),
                Preco = 1                
            };

            _produtoRepository.Create(produto);
            _context.SaveChanges();
            Assert.IsTrue(true);
        }

        [Test]
        [Order(31)]
        public void InserirProdutos_Handler()
        {
            var produto = new Produto()
            {
                Descricao = "Teclado",
                FabricanteId = Guid.Parse("431424A3-5734-412F-8DFC-E6A906F19AD8"),
                Preco = 2
            };

            new ProdutoHandler(_produtoRepository, new SqlHelper(_context)).Create(produto);

            //_context.SaveChanges();
            Assert.IsTrue(true);
        }
    }
}

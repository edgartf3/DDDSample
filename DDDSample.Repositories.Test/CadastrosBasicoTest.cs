using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Entities;
using DDDSample.Framework.DataBase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
        public void InserirFabricantes()
        {
            _fabricanteRepository.Create(new Fabricante("Dell"));
            _fabricanteRepository.Create(new Fabricante("Sansumg"));
            _fabricanteRepository.Create(new Fabricante("LG"));
            _context.SaveChanges();
        }

        [Test]
        [Order(1)]
        public void InserirRamosAtividade()
        {
            _ramoRepository.Create(new RamoAtividade("Shoping"));
            _ramoRepository.Create(new RamoAtividade("Galeria"));
            _ramoRepository.Create(new RamoAtividade("Manutenção"));
            _context.SaveChanges();            
        }
    }
}

using DDDSample.Domain.Venda.Entities;
using DDDSample.Framework.DataBase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Repositories.Test
{
    public class FabricanteRepositoryTest
    {
        private BaseRepository<Fabricante, SampleDBContext> _repository;

        [SetUp]
        public void Setup()
        {
            this._repository = TestHelper.CriarRepositorio<Fabricante>();

        }

        [Test]
        [Order(0)]
        public void Incluir()
        {
            _repository.Create(new Fabricante("DELL"));
            _repository.Create(new Fabricante("Acer"));
            _repository.Create(new Fabricante("Lenovo"));
            _repository.Create(new Fabricante("Positivo"));
            _repository.Create(new Fabricante("Samsung"));

            Assert.Pass();

        }
    }
}

using DDDSample.Domain.Venda.Entities;
using DDDSample.Framework.DataBase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Repositories.Test
{
    [Order(0)]
    public class FabricanteRepositoryTest
    {
        private BaseRepository<Fabricante, SampleDBContext> _repository;

        [SetUp]
        public void Setup()
        {
            var context = TestHelper.GetContexto();
            this._repository = TestHelper.CriarRepositorio<Fabricante>(context);

        }

        [Test]
        [Order(0)]
        public void Incluir()
        {
            _repository.Create(new Fabricante("DELL", Guid.Parse("B09A87F1-838F-4070-87DF-049A3AE19A0C")));
            _repository.Create(new Fabricante("Acer"));
            _repository.Create(new Fabricante("Lenovo"));
            _repository.Create(new Fabricante("Positivo"));
            _repository.Create(new Fabricante("Samsung"));

            Assert.IsTrue(true);

        }
    }
}

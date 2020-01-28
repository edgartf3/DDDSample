using DDDSample.Domain.Venda.Entities;
using DDDSample.Framework.DataBase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Repositories.Test
{
<<<<<<< HEAD
=======
    [Order(0)]
>>>>>>> 397fc590adfb3a2a5a095a83686192d24a075271
    public class FabricanteRepositoryTest
    {
        private BaseRepository<Fabricante, SampleDBContext> _repository;

        [SetUp]
        public void Setup()
        {
<<<<<<< HEAD
            this._repository = TestHelper.CriarRepositorio<Fabricante>();
=======
            var context = TestHelper.GetContexto();
            this._repository = TestHelper.CriarRepositorio<Fabricante>(context);
>>>>>>> 397fc590adfb3a2a5a095a83686192d24a075271

        }

        [Test]
        [Order(0)]
        public void Incluir()
        {
<<<<<<< HEAD
            _repository.Create(new Fabricante("DELL"));
=======
            _repository.Create(new Fabricante("DELL", Guid.Parse("B09A87F1-838F-4070-87DF-049A3AE19A0C")));
>>>>>>> 397fc590adfb3a2a5a095a83686192d24a075271
            _repository.Create(new Fabricante("Acer"));
            _repository.Create(new Fabricante("Lenovo"));
            _repository.Create(new Fabricante("Positivo"));
            _repository.Create(new Fabricante("Samsung"));

<<<<<<< HEAD
            Assert.Pass();
=======
            Assert.IsTrue(true);
>>>>>>> 397fc590adfb3a2a5a095a83686192d24a075271

        }
    }
}

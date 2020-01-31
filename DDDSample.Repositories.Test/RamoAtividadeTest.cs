using DDDSample.Domain.Entities;
using DDDSample.Framework.DataBase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Repositories.Test
{
    [Order(0)]
    class RamoAtividadeTest
    {
        private BaseRepository<RamoAtividade, SampleDBContext> _repository;

        [SetUp]
        public void Setup()
        {
            var context = TestHelper.GetContexto();
            this._repository = TestHelper.CriarRepositorio<RamoAtividade>(context);

        }

        [Test]
        [Order(0)]
        public void Incluir()
        {
            _repository.Create(new RamoAtividade("Veterinário", Guid.Parse("23DF4BD9-0E02-47F9-91F4-4EFEF13DEDDB")));
            _repository.Create(new RamoAtividade("Clinica"));
            _repository.Create(new RamoAtividade("Pet-Shop"));
            

            Assert.IsTrue(true);

        }
    }
}

using DDDSample.Framework.DataBase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Repositories.Test
{
    [Order(10000)]
    class ApagarBancoDados
    {
        private SampleDBContext _context;
        [SetUp]
        public void Setup()
        {
            _context = TestHelper.GetContexto();
        }

        [Test]
        [Order(0)]
        public void Finaliza()
        {
            //_context.Database.EnsureDeleted();
        }
    }
}

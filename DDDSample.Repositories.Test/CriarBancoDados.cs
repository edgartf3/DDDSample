using DDDSample.Framework.DataBase;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Repositories.Test
{
    [Order(0)]
    public class CriarBancoDados
    {
        private SampleDBContext _context;
        [SetUp]
        public void Setup()
        {
            _context = TestHelper.GetContexto();
        }

        [Test]
        [Order(1)]
        public void MigrationInitial()
        {
            _context.Database.Migrate();
        }
    }
}

using DDDSample.Domain.Core.Entities;
using DDDSample.Framework.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Repositories.Test
{
    public class TestHelper
    {
        public static BaseRepository<T, SampleDBContext> CriarRepositorio<T>(SampleDBContext context) where T:EntidadeBase
        {            
            return new BaseRepository<T, SampleDBContext>(context);
        }

        public static SampleDBContext GetContexto()
        {
            var connectionString = "Data Source=localhost;Initial Catalog=DDDSampleTest;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; MultipleActiveResultSets=true";

            var options = new DbContextOptionsBuilder<SampleDBContext>()
                .UseSqlServer(connectionString)
                .Options;


            var _context = new SampleDBContext(options);
            

            return _context;

        }
    }
}

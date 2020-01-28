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
<<<<<<< HEAD
        public static BaseRepository<T, SampleDBContext> CriarRepositorio<T>() where T:EntidadeBase
        {
            var connectionString = "Data Source=localhost;Initial Catalog=DDDSampleTest;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; MultipleActiveResultSets=true";
          
=======
        public static BaseRepository<T, SampleDBContext> CriarRepositorio<T>(SampleDBContext context) where T:EntidadeBase
        {
            

            return new BaseRepository<T, SampleDBContext>(context);

        }

        public static SampleDBContext GetContexto()
        {
            var connectionString = "Data Source=localhost;Initial Catalog=DDDSampleTest;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; MultipleActiveResultSets=true";

>>>>>>> 397fc590adfb3a2a5a095a83686192d24a075271
            var options = new DbContextOptionsBuilder<SampleDBContext>()
                .UseSqlServer(connectionString)
                .Options;


            var _context = new SampleDBContext(options);
            _context.Database.Migrate();

<<<<<<< HEAD
            return new BaseRepository<T, SampleDBContext>(_context);
=======
            return _context;
>>>>>>> 397fc590adfb3a2a5a095a83686192d24a075271

        }
    }
}

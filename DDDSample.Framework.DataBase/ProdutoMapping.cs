using DDDSample.Domain.Entities;
using DDDSample.Framework.DataBase.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Framework.DataBase
{
    public class ProdutoMapping: BaseMapping<Produto>
    {
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

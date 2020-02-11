using DDDSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Framework.DataBase.Mappings
{
    class DependenteMapping: BaseMapping<Dependente>, IMapping
    {
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            entity.HasOne(b => b.Pessoa)
            .WithMany(a => a.Dependentes)
            .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}

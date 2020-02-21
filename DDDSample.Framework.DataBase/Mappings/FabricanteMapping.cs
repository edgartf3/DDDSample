using DDDSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Framework.DataBase.Mappings
{
    public class FabricanteMapping : BaseMapping<Fabricante>, IMapping
    {
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            entity.Property(a => a.Descricao).IsRequired();
            entity.HasIndex(a => a.Descricao).HasName("unqFabricanteDescricao").IsUnique();
        }
    }
}

using DDDSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DDDSample.Framework.DataBase.Mappings
{
    class VendaMapping : BaseMapping<Venda>, IMapping
    {
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
            entity.Property(a => a.Data).IsRequired().HasColumnType("Date");
            entity.Property(a => a.Numero).ValueGeneratedOnAdd();
        }
    }
}

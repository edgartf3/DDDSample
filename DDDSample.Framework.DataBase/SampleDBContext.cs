using DDDSample.Domain.Entities;
using DDDSample.Domain.Venda.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Framework.DataBase
{
    public class SampleDBContext: DbContext
    {
        public SampleDBContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }

        public DbSet<RamoAtividade> RamosAtividade { get; set; }

    }
}

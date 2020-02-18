using DDDSample.Domain.Entities;
using DDDSample.Domain.ValuesObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Framework.DataBase.Mappings
{
    class PessoaMapping: BaseMapping<Pessoa>, IMapping
    {
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            entity.HasIndex(a => a.Cpf_CNPJ).HasName("unqPessoaCpf_Cnpj").IsUnique();

            entity.OwnsOne(p => p.Entrega)
               .ToTable("Pessoa_Endereco_Entrega")
                .HasOne(a => a.Pessoa)
                .WithOne(a => a.Entrega)
                .OnDelete(DeleteBehavior.Cascade);

            entity.OwnsOne(p => p.Faturamento)
                .ToTable("Pessoa_Endereco_Faturamento")
                .HasOne(a => a.Pessoa)
                .WithOne(a => a.Faturamento)
                .OnDelete(DeleteBehavior.Cascade);

             

        }
    }
}

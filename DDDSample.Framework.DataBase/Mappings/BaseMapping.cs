using DDDSample.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Framework.DataBase.Mappings
{
    public class BaseMapping<TEntity> where TEntity : EntidadeBase
    {
        protected EntityTypeBuilder<TEntity> entity;

        public virtual void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.entity = modelBuilder.Entity<TEntity>();
            entity.HasKey(t => t.Id);            
        }
    }
}

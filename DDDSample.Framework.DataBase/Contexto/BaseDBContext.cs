using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DDDSample.Framework.DataBase.Contexto
{
    public class BaseDBContext: DbContext
    {
        private IDbContextTransaction _transaction;
        public BaseDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbConnection GetConnection()
        {
            return this.Database.GetDbConnection();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Todo campo que for do tipo decimal, fica configurado para duas casas
            foreach (var pb in modelBuilder.Model
               .GetEntityTypes()
               .SelectMany(t => t.GetProperties())
               .Where(p =>
                   p.ClrType == typeof(decimal) ||
                   p.ClrType == typeof(decimal?))
               .Select(p =>
                   modelBuilder.Entity(p.DeclaringEntityType.ClrType)
                       .Property(p.Name)))
            {
                pb.HasColumnType("decimal(18,2)");
            }
        }
    }
}

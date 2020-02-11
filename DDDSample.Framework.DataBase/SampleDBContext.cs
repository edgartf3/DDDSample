using DDDSample.Domain.Entities;
using DDDSample.Framework.DataBase.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

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
            


            #region ajustando FKs            
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {                                     
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

                /*
                if (relationship.Properties.Count != 0)
                {
                    var prop = relationship.Properties[0];
                    var PTR = prop.PropertyInfo;
                    if (PTR != null)
                    {
                        
                        var attributes = PTR.CustomAttributes;
                        foreach (var attribute in attributes)
                        {
                            if (attribute.AttributeType.Name.ToLower() == "cascade")
                            {
                                relationship.DeleteBehavior = DeleteBehavior.Cascade;
                            }
                        }
                    }                                                                                   
                } */
            }            
            #endregion


                       

            
            //Dynamic Mapping by Reflection
            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                  where x.IsClass && typeof(IMapping).IsAssignableFrom(x)
                                  select x).ToList();

            foreach (var mapping in typesToMapping)
            {
                IMapping mappingClass = Activator.CreateInstance(mapping) as IMapping;
                mappingClass.OnModelCreating(modelBuilder);
            }
           
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<RamoAtividade> RamosAtividade { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }

    }
}

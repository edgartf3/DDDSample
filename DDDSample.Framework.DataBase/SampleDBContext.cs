using DDDSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {                                     
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

                
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
                }                              
            }

            

            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //Não fazer FKs nos relacinamentos 1-N com Delete Cascade habilitado *É Perigoso!!
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); //Não fazer FKs nos relacionamentos N-N com Delete Cascade Habilitado *É Perigoso!!


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

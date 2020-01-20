using DDDSample.Domain.Core;
using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Venda.Entities;
using DDDSample.Framework.DataBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDDSample.IoC.Venda
{
    public class BindingsContainers
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBaseService<Produto>, BaseService<Produto>>();
            services.AddScoped<IBaseRepository<Produto>, BaseRepository<Produto>>();

            services.AddScoped<IBaseService<Cliente>, BaseService<Cliente>>();
            services.AddScoped<IBaseRepository<Cliente>, BaseRepository<Cliente>>();

        }
    }
}

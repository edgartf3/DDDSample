using DDDSample.Domain.Core;
using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Venda.Entities;
using DDDSample.Framework.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDDSample.IoC
{
    public class BindingsContainers
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SampleDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("SampleConnection")));
            services.AddScoped<SampleDBContext, SampleDBContext>(); //Assim que acabar a requisão, acabar com a conexão com o banco de Dados
            services.AddScoped<IBaseService<Produto>, BaseService<Produto>>();
            services.AddScoped<IBaseRepository<Produto>, BaseRepository<Produto>>();

            services.AddScoped<IBaseService<Pessoa>, BaseService<Pessoa>>();
            services.AddScoped<IBaseRepository<Pessoa>, BaseRepository<Pessoa>>();

            services.AddScoped<IBaseService<Venda>, BaseService<Venda>>();
            services.AddScoped<IBaseRepository<Venda>, BaseRepository<Venda>>();

            services.AddScoped<IBaseService<Item>, BaseService<Item>>();
            services.AddScoped<IBaseRepository<Item>, BaseRepository<Item>>();

        }
    }
}

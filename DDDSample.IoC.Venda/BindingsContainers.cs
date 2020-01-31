using DDDSample.Application.AppServices;
using DDDSample.Application.Interfaces;
using DDDSample.Application.ViewsModels;
using DDDSample.Domain.Core;
using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Entities;
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
            services.AddScoped<IBaseRepository<Produto>, BaseRepository<Produto, SampleDBContext>>();

            services.AddScoped<IBaseService<Pessoa>, BaseService<Pessoa>>();
            services.AddScoped<IBaseRepository<Pessoa>, BaseRepository<Pessoa, SampleDBContext>>();

            services.AddScoped<IBaseService<Venda>, BaseService<Venda>>();
            services.AddScoped<IBaseRepository<Venda>, BaseRepository<Venda, SampleDBContext>>();

            services.AddScoped<IBaseService<Item>, BaseService<Item>>();
            services.AddScoped<IBaseRepository<Item>, BaseRepository<Item, SampleDBContext>>();

            services.AddScoped<IBaseService<Fabricante>, BaseService<Fabricante>>();
            services.AddScoped<IBaseRepository<Fabricante>, BaseRepository<Fabricante, SampleDBContext>>();

            services.AddScoped<IBaseService<RamoAtividade>, BaseService<RamoAtividade>>();
            services.AddScoped<IBaseRepository<RamoAtividade>, BaseRepository<RamoAtividade, SampleDBContext>>();            
            services.AddScoped<IBaseServiceApp<RamoAtividadeViewModel>, BaseServiceApp<RamoAtividadeViewModel, RamoAtividade>>();

        }
    }
}

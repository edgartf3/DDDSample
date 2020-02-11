using DDDSample.Application.Core;
using DDDSample.Application.Services;
using DDDSample.Application.Services.Interfaces;
using DDDSample.Application.ViewsModels;
using DDDSample.Domain.Core;
using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Entities;
using DDDSample.Domain.Interfaces.Services;
using DDDSample.Domain.Services;
using DDDSample.Framework.DataBase;
using DDDSample.Framework.DataBase.UoW;
using DDDSample.Framework.DataBase.UoW.Interfaces;
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBaseHandler<Produto>, BaseHandler<Produto>>();
            services.AddScoped<IBaseRepository<Produto>, BaseRepository<Produto, SampleDBContext>>();
            services.AddScoped<IBaseService<Produto>, BaseService<Produto, Produto>>();

            services.AddScoped<IBaseHandler<Pessoa>, BaseHandler<Pessoa>>();
            services.AddScoped<IBaseRepository<Pessoa>, BaseRepository<Pessoa, SampleDBContext>>();
            services.AddScoped<IBaseService<Pessoa>, BaseService<Pessoa, Pessoa>>();

            services.AddScoped<IBaseHandler<Venda>, BaseHandler<Venda>>();
            services.AddScoped<IBaseRepository<Venda>, BaseRepository<Venda, SampleDBContext>>();
            services.AddScoped<IBaseService<Venda>, VendaService>();
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IVendaHandler, VendaHandler>();


            services.AddScoped<IBaseHandler<Item>, BaseHandler<Item>>();
            services.AddScoped<IBaseRepository<Item>, BaseRepository<Item, SampleDBContext>>();
            services.AddScoped<IBaseService<Item>, BaseService<Item, Item>>();

            services.AddScoped<IBaseHandler<Fabricante>, BaseHandler<Fabricante>>();
            services.AddScoped<IBaseRepository<Fabricante>, BaseRepository<Fabricante, SampleDBContext>>();
            services.AddScoped<IBaseService<Fabricante>, BaseService<Fabricante, Fabricante>>();

            services.AddScoped<IBaseHandler<RamoAtividade>, BaseHandler<RamoAtividade>>();
            services.AddScoped<IBaseRepository<RamoAtividade>, BaseRepository<RamoAtividade, SampleDBContext>>();            
            services.AddScoped<IBaseService<RamoAtividadeViewModel>, BaseService<RamoAtividadeViewModel, RamoAtividade>>();

            services.AddScoped<IBaseHandler<Vendedor>, BaseHandler<Vendedor>>();
            services.AddScoped<IBaseRepository<Vendedor>, BaseRepository<Vendedor, SampleDBContext>>();
            services.AddScoped<IBaseService<Vendedor>, BaseService<Vendedor, Vendedor>>();


            services.AddSingleton<ServiceProvider>(services.BuildServiceProvider());
            services.AddScoped<IInjector, Injector>();

        }
    }
}

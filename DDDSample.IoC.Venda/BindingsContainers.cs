using Applications.Services.Venda;
using DDDSample.Domain.Venda.Entities;
using DDDSample.Domain.Venda.Interfaces;
using DDDSample.Framework.DataBase.Interfaces;
using DDDSample.Framework.DataBase.Repositories;
using DDDSample.Services.Venda.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DDDSample.IoC.Venda
{
    public class BindingsContainers
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProduto, Produto>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}

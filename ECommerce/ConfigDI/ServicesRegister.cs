

using ECommerce.Model.EFModel.Models;
using ECommerce.Services.Implements;
using ECommerce.Services.Interfaces;
using ECommerce.Services.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.ConfigDI
{
    public static class ServicesRegister
    {

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            services.AddTransient<IProductService, ProductService>();
            //UnitOfWork 
            services.AddTransient<IUnitOfWork<Product>, UnitOfWork<Product>>();
            //BaseRepository
            
            return services;
        }


    }
}

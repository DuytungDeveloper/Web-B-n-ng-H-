

using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using ECommerce.Services.Implements;
using ECommerce.Services.Interfaces;
using ECommerce.Services.Repository;
using ECommerce.Services.UnitOfWork;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.ConfigDI
{
   
    public static class ServicesRegister
    {
       
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            services.AddTransient<IProductService<Product>, ProductService<Product>>();

            #region
            //UnitOfWork 
            services.AddTransient<IUnitOfWork<BrandProduct>, UnitOfWork<BrandProduct>>();
            services.AddTransient<IUnitOfWork<Address>, UnitOfWork<Address>>();
            services.AddTransient<IUnitOfWork<Chatelaine>, UnitOfWork<Chatelaine>>();
            services.AddTransient<IUnitOfWork<City>, UnitOfWork<City>>();
            services.AddTransient<IUnitOfWork<ColorClockFace>, UnitOfWork<ColorClockFace>>();
            services.AddTransient<IUnitOfWork<Customer>, UnitOfWork<Customer>>();
            services.AddTransient<IUnitOfWork<District>, UnitOfWork<District>>();
            services.AddTransient<IUnitOfWork<Hem>, UnitOfWork<Hem>>();
            services.AddTransient<IUnitOfWork<HuntingCase>, UnitOfWork<HuntingCase>>();
            services.AddTransient<IUnitOfWork<Images>, UnitOfWork<Images>>();
            services.AddTransient<IUnitOfWork<Machine>, UnitOfWork<Machine>>();
            services.AddTransient<IUnitOfWork<MadeIn>, UnitOfWork<MadeIn>>();
            services.AddTransient<IUnitOfWork<OrderItem>, UnitOfWork<OrderItem>>();
            services.AddTransient<IUnitOfWork<Order>, UnitOfWork<Order>>();
            services.AddTransient<IUnitOfWork<OrderStatus>, UnitOfWork<OrderStatus>>();
            services.AddTransient<IUnitOfWork<Origin>, UnitOfWork<Origin>>();
            services.AddTransient<IUnitOfWork<Product>, UnitOfWork<Product>>();
            services.AddTransient<IUnitOfWork<Ward>, UnitOfWork<Ward>>();
            //BaseRepository
            #endregion
            return services;
        }


    }
}

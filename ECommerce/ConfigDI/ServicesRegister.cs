using ECommerce.Services.Implements;
using ECommerce.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.ConfigDI
{
    public static class ServicesRegister
    {

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {


            services.AddTransient<IProductService,ProductService>();
            return services;
        }


    }
}

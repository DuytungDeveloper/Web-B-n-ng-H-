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

            //services.AddScoped<IRepository, DapperRepository>();
            return services;
        }


    }
}

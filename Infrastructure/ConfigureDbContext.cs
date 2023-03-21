using System;
using System.Reflection;
using Server.data;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class ConfigureDbContext
    {

        public static IServiceCollection DbConfigure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseLazyLoadingProxies(true);
                opt.UseSqlServer(configuration["ConnectionStrings:EntityCore"]);
            });


            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseLazyLoadingProxies(true);
                opt.UseSqlServer(configuration["ConnectionStrings:Identity"]);
            });

            return services;
        }
    }
}


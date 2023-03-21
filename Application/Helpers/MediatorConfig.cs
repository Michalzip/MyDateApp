using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class MediatoraConfig
    {
        public static IServiceCollection AddMediatorConfig(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("Server")));

            return services;
        }
    }
}
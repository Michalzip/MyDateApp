
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer.Infrastructure.Context;

namespace IdentityServer.Infrastructure.Sql
{
    public static class DbConnection
    {
        public static IServiceCollection DbConfigure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseLazyLoadingProxies(true);
                opt.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}

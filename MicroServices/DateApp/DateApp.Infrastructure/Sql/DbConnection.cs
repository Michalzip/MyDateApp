
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace DateApp.Infrastructure.Sql
{

    public static class DbConnection
    {
        public static IServiceCollection DbConfigure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CoreContext>(opt =>
            {
                opt.UseLazyLoadingProxies(true);
                opt.UseSqlServer(connectionString);
            });


            return services;
        }
    }

}
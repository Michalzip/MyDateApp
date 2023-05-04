
using IdentityServer.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Shared.Models;

namespace IdentityServer.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureScoped(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<ApplicationUser>();

            return services;
        }
    }
}
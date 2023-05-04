using System.Reflection;
using IdentityServer.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainScoped(this IServiceCollection services)
        {
            return services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()))
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IDentityUserService, IdentityUserService>();

        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Domain.Policies.UserVipProfile;
using Domain.Policies.UserProfile;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Application")]
namespace Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainScoped(this IServiceCollection services)
        {
            return services
            .AddScoped<IAuthorizationHandler, RequirementHandler>()
            .AddScoped<IAuthorizationHandler, RequirementVipHandler>();
        }
    }
}
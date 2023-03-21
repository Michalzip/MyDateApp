using System.Reflection;
using Server.Functions.UserFunctions.Commands;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Domain;

namespace Application
{
    public static class ServicesInjector
    {
        public static void InjectServices(this IServiceCollection services)
        {

            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ContextAccessorExtension>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddDomainScoped();
            services.AddInfrastructureScoped();

        }

    }

}
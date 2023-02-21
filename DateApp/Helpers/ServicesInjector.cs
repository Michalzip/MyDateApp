using DateApp.Services;
using DateApp.Repositories;
using DateApp.Repositories.Interfaces;
using Api.Extensions;
using Api.Policy;
using Api.Policies.UserVipProfile;
using Server.Services;
using Server.Functions.UserFunctions.Commands;

namespace DateApp.Helpers
{
    public static class ServicesInjector
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<UserProfileService>();
            services.AddScoped<AppDbContext>();
            services.AddScoped<IPaypalRepository, PayPalRepository>();
            services.AddScoped<ContextAccessorExtension>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IAuthorizationHandler, RequirementHandler>();
            services.AddScoped<IAuthorizationHandler, RequirementVipHandler>();
            services.AddScoped<AuthenticateUserCommand>();

        }
    }
}
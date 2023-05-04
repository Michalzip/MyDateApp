using Domain.Interfaces.Repositories;
using Infrastructure.Repositories;
using Domain.Interfaces.ExternalServices;
using Infrastructure.Services;
using DateApp.Infrastructure.Middlewares;

namespace Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureScoped(this IServiceCollection services)
        {
            return services
            .AddScoped<ILikeRepository, LikeRepository>()
            .AddScoped<IUserProfileRepository, UserProfileRepository>()
            .AddScoped<IMessageRepository, MessageRepository>()
            .AddScoped<ITransactionRepository, TransactionRepository>()
            .AddScoped<IPaypalService, PayPalService>()
            .AddScoped<JwtAuthenticationMiddleware>();
        }
    }
}
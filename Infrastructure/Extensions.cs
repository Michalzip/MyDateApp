using Domain.Interfaces.Repositories;
using Infrastructure.Repositories;
using Domain.Interfaces.ExternalApiServices;
using Infrastructure.Services;
using Server.Services;
using Server.Services.Interface;
using Infrastructure.Services;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Db;
using Server.data;
using Infrastructure.Db;

[assembly: InternalsVisibleTo("Application")]

namespace Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructureScoped(this IServiceCollection services)
        {

            return services
            .AddScoped<ILikeRepository, LikeRepository>()
            .AddScoped<IUserProfileRepository, UserProfileRepository>()
            .AddScoped<IMessageRepository, MessageRepository>()
            .AddScoped<ITransactionRepository, TransactionRepository>()
            .AddScoped<IPaypalService, PayPalService>()
            .AddScoped<IUserService, UserService>();

        }


    }
}
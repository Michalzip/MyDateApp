using System.Reflection;

namespace DateApp.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainScoped(this IServiceCollection services)
        {
            return services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()))
            .AddScoped<IUserProfileService, UserProfileService>()
            .AddScoped<ITransactionService, TransactionService>()
            .AddScoped<ILikeService, LikeService>()
            .AddScoped<IMessageService, MessageService>();
        }
    }
}
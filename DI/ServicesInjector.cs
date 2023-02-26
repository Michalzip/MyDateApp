using App.Db;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Extensions;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;
using Server.Services;
using Server.Services.Interface;
using Server.Functions.UserFunctions.Commands;
using Server.data;
using Infrastructure.Services.Interfaces;
using Infrastructure.Services;
using DateApp.Services;
using App.Services;
using Infrastructure.Repositories;

namespace DI
{
    public static class ServicesInjector
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<UserProfileService>();
            services.AddScoped<AppDbContext>();

            services.AddScoped<ContextAccessorExtension>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IMessageService, MessageService>();
            // services.AddScoped<IAuthorizationHandler, RequirementHandler>();
            // services.AddScoped<IAuthorizationHandler, RequirementVipHandler>();

            //Repositories
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            //Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();

            //External services
            services.AddScoped<IPaypalService, PayPalService>();

            services.AddScoped<AuthenticateUserCommand>();

        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseLazyLoadingProxies(true);
                opt.UseSqlServer(configuration["ConnectionStrings:EntityCore"]);
            });

            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseLazyLoadingProxies(true);
                opt.UseSqlServer(configuration["ConnectionStrings:Identity"]);
            });
        }
    }
}


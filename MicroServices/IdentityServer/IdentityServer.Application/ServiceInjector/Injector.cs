
using IdentityServer.Domain;
using System.Reflection;
using Shared.Abstraction.Configs.Mapper;
using IdentityServer.Domain.Interfaces.Messages;
using IdentityServer.Infrastructure.Messages.Queques;
using IdentityServer.Infrastructure.Messages.Rpc;
using Shared.Middlewares;
using System.Security.Claims;
using IdentityServer.Infrastructure;
namespace IdentityServer.Application.ServiceInjector
{
    internal static class Injector
    {
        internal static IServiceCollection Add(this IServiceCollection services)
        {
            services.AddScoped<IMessagePublisher, Publisher>();
            services.AddScoped<RpcServer>();
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<ApplicationUser>();
            services.AddScoped<ExceptionMiddleware>();
            services.AddSwaggerGen();

            services.AddMapperConfig(Assembly.GetExecutingAssembly());
            services.AddDomainScoped();
            services.AddInfrastructureScoped();
            services.AddControllersWithViews();
            services.AddControllers();
            services.AddAuthorization(options => options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.NameIdentifier, "65968e57-9d7c-42f5-802a-16500385a1bb")));

            return services;
        }

        public static IApplicationBuilder Use(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.OAuth2RedirectUrl("https://localhost:7096/");
                options.RoutePrefix = string.Empty;

            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseAuthorization();
            return app;

        }
    }
}
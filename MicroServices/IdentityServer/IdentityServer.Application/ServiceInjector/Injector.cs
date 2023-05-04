
using IdentityServer.Domain;
using IdentityServer.Infrastructure.Context;
using System.Reflection;
using Shared.Abstraction.Configs.Mapper;
using IdentityServer.Domain.Interfaces.Messages;
using IdentityServer.Infrastructure.Messages.Queques;
using IdentityServer.Infrastructure.Messages.Rpc;
using IdentityServer.Domain.Interfaces.Services;
using IdentityServer.Application.Services;
using Shared.Middlewares;
using System.Security.Claims;

namespace IdentityServer.Application.ServiceInjector
{
    public static class Injector
    {
        public static IServiceCollection Add(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddScoped<IMessagePublisher, Publisher>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDentityUserService, IdentityUserService>();

            services.AddScoped<RpcServer>();
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<ApplicationUser>();
            services.AddScoped<ExceptionMiddleware>();
            services.AddSwaggerGen();

            services.AddMapperConfig(Assembly.GetExecutingAssembly());
            services.AddDomainScoped();
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

using IdentityServer.Application.Services.Interfaces;
using IdentityServer.Application.Services;
using IdentityServer.Infrastructure.Context;
using System.Reflection;
using Shared.Abstraction.Configs.Swagger;
using Shared.Abstraction.Configs.Mapper;

namespace IdentityServer.Application.ServiceInjector
{
    public static class Injector
    {
        public static IServiceCollection Add(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddScoped<IAuthService, AuthService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddMapperConfig(Assembly.GetExecutingAssembly());
            services.AddSwaggerConfig();

            services.AddSession();
            services.AddControllersWithViews();
            services.AddControllers();
            return services;

        }

        public static IApplicationBuilder Use(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSession();
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
            // app.UseIdentityServer();
            app.UseAuthorization();

            return app;

        }
    }
}
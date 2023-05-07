using System.Reflection;
using Infrastructure;
using Shared.Abstraction.Configs.Mapper;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DateApp.Domain.Interfaces.Messages;
using DateApp.Infrastructure.Messages.Queques;
using DateApp.Domain.Auth;
using DateApp.Infrastructure.Messages.Rpc;
using Shared.Jwt;
using DateApp.Infrastructure.Middlewares;
using Shared.Middlewares;
using DateApp.Domain;
namespace DateApp.Application.ServiceInjector
{
    internal static class Injector
    {
        internal static IServiceCollection Add(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<Receiver>();
            services.AddScoped<IRpcClient, RpcClient>();
            services.AddScoped<IMessagePublisher, Publisher>();

            services.AddScoped<IAuthorizationHandler, RequirementHandler>();
            services.AddScoped<IAuthorizationHandler, RequirementVipHandler>();

            services.AddScoped<ExceptionMiddleware>();
            services.AddSingleton<ITokenService, TokenService>();

            services.AddScoped<ContextAccessorExtension>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDomainScoped();
            services.AddInfrastructureScoped();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ETB4GNHYY2ETB4GNHYY2")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.NameIdentifier, "65968e57-9d7c-42f5-802a-16500385a1bb"));

                options.AddPolicy("UserProfile", policy => { policy.Requirements.Add(new UserProfilePolicy()); policy.RequireAuthenticatedUser(); });

                options.AddPolicy("UserVipProfile", policy => { policy.Requirements.Add(new UserVipProfilePolicy()); policy.RequireAuthenticatedUser(); });
            });

            services.AddMapperConfig(Assembly.GetExecutingAssembly());
            services.AddSwaggerGen();

            services.AddSession();
            services.AddControllersWithViews();
            services.AddControllers();

            return services;
        }

        public static IApplicationBuilder Use(this IApplicationBuilder app)
        {
            app.UseMiddleware<JwtAuthenticationMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwagger();
            app.UseSession();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.OAuth2RedirectUrl("https://localhost:7141/");
                options.RoutePrefix = string.Empty;

            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            return app;

        }
    }
}
using System.Reflection;
using Infrastructure;
using Shared.Abstraction.Configs.Swagger;
using Shared.Abstraction.Configs.Mapper;
// using IdentityServer.Application.Services;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
// using DateApp.Application.Auth.UserProfile;
// using DateApp.Application.Auth.UserVipProfile;
using DateApp.Domain.Interfaces.Messages;
//!using DateApp.Infrastructure.Messages;
using Microsoft.AspNetCore.Authentication.Cookies;
// using IdentityServer.Infrastructure.Context;
using DateApp.Infrastructure.Rpc;

namespace DateApp.Application.ServiceInjector
{
    public static class Injector
    {
        public static IServiceCollection Add(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddHttpContextAccessor();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("IdentityServer.Application")));
            services.AddScoped<IUserProfileService, UserProfileService>();
            // services.AddScoped<IDentityUserService, IdentityUserService>();
            //services.AddScoped<ICoreRabbitMqService, CoreRabbitMqService>();
            services.AddScoped<RpcClient>();

            //services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ContextAccessorExtension>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ILikeService, LikeService>();
            //services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddScoped<IMessageService, MessageService>();
            services.AddInfrastructureScoped();
            //services.AddScoped<ITokenService, TokenService>();






            //     services.AddAuthentication(options =>
            //   {
            //       options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
            //       options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
            //       options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            //       options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            //   })
            //       .AddCookie(options =>
            //       {
            //           options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
            //           options.SlidingExpiration = true;
            //           options.LoginPath = "/https://localhost:7141";
            //       })
            //       .AddJwtBearer(options =>
            //       {
            //           options.Audience = options.Audience = "api1";
            //           options.Authority = "https://localhost:7141";

            //           options.TokenValidationParameters = new TokenValidationParameters
            //           {
            //               ValidateIssuer = true,
            //               ValidateAudience = true,
            //               ValidateLifetime = true,
            //               ValidateIssuerSigningKey = true,
            //               ValidIssuer = configuration["Jwt:Issuer"],
            //               ValidAudience = configuration["Jwt:Audience"],
            //               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            //           };
            //       });

            //     services.AddAuthorization(options =>
            //     {
            //         options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Email, "julek@gmail.com"));

            //         options.AddPolicy("UserProfile", policy => { policy.Requirements.Add(new UserProfilePolicy()); policy.RequireAuthenticatedUser(); });

            //         options.AddPolicy("UserVipProfile", policy => { policy.Requirements.Add(new UserVipProfilePolicy()); policy.RequireAuthenticatedUser(); });
            //     });

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
                options.OAuth2RedirectUrl("https://localhost:7141/");
                options.RoutePrefix = string.Empty;

            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            return app;

        }
    }
}
using Microsoft.OpenApi.Models;

namespace Application
{
    public static class Extensions
    {
        public static IServiceCollection Add(this IServiceCollection services)
        {


            services.AddSession();

            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Google Auth",
                    Version = "v1"
                });

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "ouath",
                    Name = "oauth2.0",
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {

                            AuthorizationUrl = new Uri($"https://accounts.google.com/o/oauth2/v2/auth"),

                            TokenUrl = new Uri($"https://oauth2.googleapis.com/token"),

                            Scopes = new Dictionary<string, string>
                    {
                        {
                            $"https://www.googleapis.com/auth/cloud-platform.read-only",
                            "User"
                        }

                    }
                        }
                    }
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference { Id = "oauth2",
                                Type = ReferenceType.SecurityScheme},
                            Scheme="oauth2",
                            Name = "authorization",

                        },new List<string>()
                    }
                });
            });


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
                options.OAuth2RedirectUrl("https://localhost:7189/");
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
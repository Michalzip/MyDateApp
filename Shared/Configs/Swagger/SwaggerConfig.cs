

using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Shared.Abstraction.Configs.Swagger
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                        {
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


                    });

            return services;
        }
    }
}
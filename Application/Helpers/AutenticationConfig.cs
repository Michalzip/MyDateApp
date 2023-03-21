
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace Application.Helpers
{
    public static class AutenticationConfig
    {
        public static IServiceCollection AddAuthenticationConfig(this IServiceCollection services, ConfigurationManager configuration)
        {

            services.AddAuthentication(options =>
          {
              options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
              options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
              options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
              options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

          })
                          .AddCookie("Cookies", options =>
                          {

                              options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                              options.SlidingExpiration = true;
                              options.LoginPath = "/https://localhost:7189";
                          })
                          .AddJwtBearer(options =>
          {
              options.Audience = options.Audience = "api1";
              options.Authority = "https://localhost:7189";

              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  ValidIssuer = configuration["Jwt:Issuer"],
                  ValidAudience = configuration["Jwt:Audience"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
              };
          });

            return services;
        }

    }
}

using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using DI;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((config =>
{
    config.AddJsonFile("secret.json");
}));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(c =>
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

ServicesInjector.InjectServices(builder.Services);
ServicesInjector.AddDbContext(builder.Services, builder.Configuration);



var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


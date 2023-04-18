using System.Collections.Immutable;
using IdentityServer.Application.ServiceInjector;
using IdentityServer.Infrastructure.Sql;
using IdentityServer.Infrastructure.Rpc;

using RabbitMQ.Client;
using System.Security.Claims;

// using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



var migrationsAssembly = typeof(Program).Assembly.GetName().Name;
builder.Host.ConfigureAppConfiguration((config => config.AddJsonFile("Configs/secret.json")));


builder.Services.AddMvc();

builder.Services.Add();


var connectionString = builder.Configuration["ConnectionString:Identity"];
builder.Services.DbConfigure(connectionString);



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    // options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
          .AddCookie(options =>
          {
              options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
              options.SlidingExpiration = true;
              options.LoginPath = "https://localhost:7096";
          });




builder.Services.AddAuthorization();


//!System.NullReferenceException: Object reference not set to an instance of an object.
// var serviceProvider = new ServiceCollection().AddHttpContextAccessor().BuildServiceProvider();
// var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
// var sourceUserName = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);



builder.Services.AddHostedService<RpcServer>();


builder.Services.AddControllers();
builder.Services.AddHttpClient();


var app = builder.Build();

app.UseRouting();

app.Use();
app.MapControllers();

app.UseCors("AnyOrigin");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

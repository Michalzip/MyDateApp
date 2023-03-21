using System.Reflection;
using Application.Helpers;
using Application;
using Server.data;
using Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((config => config.AddJsonFile("secret.json")));

builder.Services.Add();

builder.Services.AddMediatorConfig();

builder.Services.InjectServices();

builder.Services.AddMapperConfig(Assembly.GetExecutingAssembly());

builder.Services.DbConfigure(builder.Configuration);

builder.Services.AddAuthenticationConfig(builder.Configuration);

builder.Services.AddAuthorizationConfig();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

var app = builder.Build();

app.Use();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


using IdentityServer.Application.ServiceInjector;
using IdentityServer.Infrastructure.Sql;
using IdentityServer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var migrationsAssembly = typeof(Program).Assembly.GetName().Name;

builder.Host.ConfigureAppConfiguration((config => config.AddJsonFile("secret.json")));

builder.Services.Add();

var connectionString = builder.Configuration["ConnectionString:Identity"];

 builder.Services.DbConfigure(connectionString);

var app = builder.Build();


app.Use();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


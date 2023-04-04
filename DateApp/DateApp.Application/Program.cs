using DateApp.Infrastructure.Sql;
using DateApp.Application.ServiceInjector;


var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((config => config.AddJsonFile("Configs/secret.json")));

builder.Services.Add(builder.Configuration);

var connectionString = builder.Configuration["ConnectionStrings:EntityCore"];

builder.Services.DbConfigure(connectionString);

var app = builder.Build();

app.Use();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


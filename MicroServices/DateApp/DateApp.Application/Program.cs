using DateApp.Infrastructure.Sql;
using DateApp.Application.ServiceInjector;
using RabbitMQ.Client;
using DateApp.Infrastructure.Messages.Queques;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((config => config.AddJsonFile("Configs/secret.json")));

builder.Services.Add();

var connectionString = builder.Configuration["ConnectionStrings:EntityCore"];

builder.Services.DbConfigure(connectionString);

builder.Services.AddHostedService<Receiver>();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Use();

app.Run();


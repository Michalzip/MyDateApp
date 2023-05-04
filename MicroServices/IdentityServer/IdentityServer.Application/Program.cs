using IdentityServer.Application.ServiceInjector;
using IdentityServer.Infrastructure.Sql;
using RabbitMQ.Client;
using IdentityServer.Infrastructure.Messages.Rpc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Add();

builder.Host.ConfigureAppConfiguration((config => config.AddJsonFile("Configs/secret.json")));

var connectionString = builder.Configuration["ConnectionString:Identity"];

builder.Services.DbConfigure(connectionString);

builder.Services.AddHostedService<RpcServer>();

var app = builder.Build();

app.Use();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


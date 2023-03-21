
using Server.data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Server.Functions.UserFunctions.Commands;
using Server.Functions.UserFunctions.Queries;
using MediatR;
using static Server.Functions.UserFunctions.Queries.GetUserByNameQuery;

var builder = WebApplication.CreateBuilder(args);

var migrationsAssembly = typeof(Program).Assembly.GetName().Name;

var connectionString = builder.Configuration["ConnectionString:connectionString"];


builder.Services.AddScoped<ApplicationUser>();


builder.Host.ConfigureAppConfiguration((config =>
{

    config.AddJsonFile("secret.json");

}));


builder.Services.AddIdentityServer()
    .AddOperationalStore(options =>
{

    options.ConfigureDbContext = b =>
    b.UseSqlServer(connectionString, opt => opt.MigrationsAssembly(migrationsAssembly));


}).AddConfigurationStore(options => options.ConfigureDbContext =
    builder => builder.UseSqlServer(
        connectionString,
        sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));


builder.Services.AddAuthorization();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();
app.Run();

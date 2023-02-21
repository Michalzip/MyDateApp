
using Server.data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Server.Helpers;

var builder = WebApplication.CreateBuilder(args);

var migrationsAssembly = typeof(Program).Assembly.GetName().Name;



var connectionString = builder.Configuration["ConnectionString:connectionString"];

builder.Services.AddDbContext<ApplicationDbContext>(builder =>
    builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());



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

ServicesInjector.InjectServices(builder.Services);

builder.Services.AddAuthorization();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();
app.Run();


using IdentityServer4.Test;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Server.data;
using Microsoft.EntityFrameworkCore.SqlServer;

using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var migrationsAssembly = typeof(Program).Assembly.GetName().Name;



var connectionString = builder.Configuration.GetConnectionString("connectionString");

builder.Services.AddDbContext<ApplicationDbContext>(builder =>
    builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


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

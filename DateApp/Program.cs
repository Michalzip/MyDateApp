
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Server.data;
using System.Reflection;
using App.Helpers;
using Api.Policy;
using Api.Policies.UserVipProfile;
using DateApp.Helpers;
using Server.Functions.UserFunctions.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();


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


builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddTransient<AppDbContext>();

builder.Services.AddAuthorization();
builder.Host.ConfigureAppConfiguration((config =>
{

    config.AddJsonFile("secret.json");

}));


builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration["ConnectionStrings:EntityCore"];
    options.UseLazyLoadingProxies(true);
    options.UseSqlServer(connectionString);


});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration["ConnectionStrings:Identity"];

    options.UseSqlServer(connectionString);

});


builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Email, "adam@gmail.com"));

    options.AddPolicy("UserProfile", policy => { policy.Requirements.Add(new UserProfileRequirement()); policy.RequireAuthenticatedUser(); });

    options.AddPolicy("UserVipProfile", policy => { policy.Requirements.Add(new UserVipProfileRequirement()); policy.RequireAuthenticatedUser(); });
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;

})
                .AddCookie("Cookies", options =>
                {

                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    options.SlidingExpiration = true;
                    options.LoginPath = "/https://localhost:7189";
                })
                .AddJwtBearer(options =>
{
    options.Audience = options.Audience = "api1";
    options.Authority = "https://localhost:7189";

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
}).AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Google:ClientId"];
    options.ClientSecret = builder.Configuration["Google:ClientSecret"];


});

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreateVipUserCommand).GetTypeInfo().Assembly);
//builder.Services.AddMediatR(typeof(AuthenticateUserCommand).GetTypeInfo().Assembly);


builder.Services.Configure<IdentityOptions>(options =>
{

    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

builder.Services.AddTransient<Mediator>();



ServicesInjector.InjectServices(builder.Services);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddSession();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
    });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();


}


app.UseSwagger();


app.UseSession();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.OAuth2RedirectUrl("https://localhost:7189/");
    options.RoutePrefix = string.Empty;

});




app.UseStaticFiles();

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseCors("AnyOrigin");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});





app.Run();


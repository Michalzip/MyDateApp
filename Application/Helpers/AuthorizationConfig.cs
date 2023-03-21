using Domain.Policies.UserProfile;
using Domain.Policies.UserVipProfile;

namespace Application.Helpers
{

    public static class AuthorizationConfig
    {
        public static IServiceCollection AddAuthorizationConfig(this IServiceCollection services)
        {

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Email, "julek@gmail.com"));

                options.AddPolicy("UserProfile", policy => { policy.Requirements.Add(new UserProfileRequirement()); policy.RequireAuthenticatedUser(); });

                options.AddPolicy("UserVipProfile", policy => { policy.Requirements.Add(new UserVipProfileRequirement()); policy.RequireAuthenticatedUser(); });
            });

            return services;
        }

    }
}
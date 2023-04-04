using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public bool isvVip { get; set; } = false;
    }
}

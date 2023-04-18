using Microsoft.AspNetCore.Identity;

namespace Shared.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool isvVip { get; set; } = false;
    }
}

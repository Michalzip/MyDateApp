using System;
using Microsoft.AspNetCore.Identity;

namespace Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool isvVip { get; set; } = false;
    }
}


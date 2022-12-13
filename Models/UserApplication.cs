using System;
using Microsoft.AspNetCore.Identity;

namespace App.Models
{
	public class ApplicationUser: IdentityUser
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? AvatarImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}


using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace App.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}


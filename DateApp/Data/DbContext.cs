using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using App.Models;
using Microsoft.AspNetCore.Identity;

namespace App.Db
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        private readonly DbContextOptions _options;
        public AppDbContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }
    }
}


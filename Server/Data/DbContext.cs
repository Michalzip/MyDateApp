using System;
using Microsoft.AspNetCore.Identity
;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Server.data
{
	public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}


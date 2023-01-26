using System;
using Microsoft.AspNetCore.Identity;
using Server.Models;

namespace Server.Repository.interfaces
{
	public interface IIdentityUserRepo
	{
        Task<ApplicationUser> GetIdentityUserByName(string userName);
        Task<ApplicationUser> GetIdentityUserByEmail(string email);
        Task<IdentityResult> InsertIdentityUser(ApplicationUser user);
        Task<SignInResult> AuthenticateIdentityUser(ApplicationUser user);
        Task<IdentityResult> SetIdentityVipUser(string userName);
    }
}


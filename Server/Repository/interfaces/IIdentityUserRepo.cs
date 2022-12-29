using System;
using Microsoft.AspNetCore.Identity;

namespace Server.Repository.interfaces
{
	public interface IIdentityUserRepo
	{
        Task<IdentityUser> GetIdentityUserByName(string userName);
        Task<IdentityResult> InsertIdentityUser(IdentityUser user);
        Task<SignInResult> AuthenticateIdentityUser(IdentityUser user);

    }
}


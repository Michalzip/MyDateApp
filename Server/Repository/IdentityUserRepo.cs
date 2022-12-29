using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Server.Repository.interfaces;

namespace Server.Repository
{
	public class IdentityUserRepo: IIdentityUserRepo
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        

        public	IdentityUserRepo(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
            _userManager = userManager;
            _signInManager = signInManager;
       
        }

        public async Task<IdentityUser> GetIdentityUserByName(string userName)
		{
            var user = await _userManager.FindByNameAsync(userName);

            return user;
        }

        public async Task<IdentityResult> InsertIdentityUser(IdentityUser user)
        {

            var result = await _userManager.CreateAsync(user, user.PasswordHash);

            return result;
        }


        public async Task<SignInResult> AuthenticateIdentityUser(IdentityUser user)
        {

            var userData = await _userManager.FindByEmailAsync(user.Email);

            var result = await _signInManager.PasswordSignInAsync(userData.UserName, user.PasswordHash, isPersistent: false, lockoutOnFailure: false);

            return result;
        }


     
    }
}


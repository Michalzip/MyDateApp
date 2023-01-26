using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Server.Repository.interfaces;
using Server.Models;

namespace Server.Repository
{
	public class IdentityUserRepo: IIdentityUserRepo
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        

        public	IdentityUserRepo(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
            _userManager = userManager;
            _signInManager = signInManager;
       
        }

        public async Task<ApplicationUser> GetIdentityUserByName(string userName)
		{
            var user = await _userManager.FindByNameAsync(userName);

            return user;
        }

        public async Task<ApplicationUser> GetIdentityUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }

        public async Task<IdentityResult> InsertIdentityUser(ApplicationUser user)
        {

            var result = await _userManager.CreateAsync(user, user.PasswordHash);

            return result;
        }


        public async Task<SignInResult> AuthenticateIdentityUser(ApplicationUser user)
        {

            var userData = await this.GetIdentityUserByEmail(user.Email);

            var result = await _signInManager.PasswordSignInAsync(userData.UserName, user.PasswordHash, isPersistent: false, lockoutOnFailure: false);

            return result;
        }

        public async Task<IdentityResult> SetIdentityVipUser(string userName)
        {

            var user = await this.GetIdentityUserByName(userName);

            user.isvVip = true;

            var result = await _userManager.UpdateAsync(user);

            return result;
            
        }
     
    }
}


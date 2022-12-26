using System;
using Microsoft.AspNetCore.Identity;

namespace Server
{
	public class IdentityService
	{
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
       
        public IdentityService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
            _userManager = userManager;
            _signInManager = signInManager;
        }
        

       
		public async Task<IdentityResult> AddIdentityUser(IdentityUser user) {

            var rezult  =   await _userManager.CreateAsync(user ,user.PasswordHash);

            return rezult;
        }
        

        public async Task<SignInResult> AuthenticateIdentityUser(IdentityUser user)
        {

            var userData = await _userManager.FindByEmailAsync(user.Email);

            var result =  await _signInManager.PasswordSignInAsync(userData.UserName, user.PasswordHash, isPersistent: false, lockoutOnFailure: false);

            return result;
        }
    }
}


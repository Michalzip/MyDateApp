using System;
using App.Db;
using App.Models;
using Microsoft.AspNetCore.Identity;
using App.Controllers;
using Microsoft.AspNetCore.Mvc;
using App.Interfaces;
namespace App.AuthRepository
{
	public class AuthRepo:IAuthRepo
	{
      
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
 

        public AuthRepo(ILogger<HomeController> logger,  UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
            
           
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
       
        }

      
        public async Task SaveUser(UserRegisterModel userSignUpForm)
        {

            try
            {
                
                var user = new ApplicationUser
                {
                    UserName = userSignUpForm.Name,
                    Email = userSignUpForm.Email,
                };

                    await _userManager.CreateAsync(user, userSignUpForm.Password);


            }
            catch (Exception e)
            {
                _logger.LogInformation($"User is not created. Excepction :{e}");
            }
        }

        public async Task SignInUser(UserLoginModel userSignInForm)
        {

            try
            {
                var user = await _userManager.FindByEmailAsync(userSignInForm.Email);
                var result = await _signInManager.PasswordSignInAsync(user.UserName, userSignInForm.Password, isPersistent: false, lockoutOnFailure: false);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"User failed authorizate :{e}");
            }
          
        }
    }


}


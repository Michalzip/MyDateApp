using System;
using App.Db;
using App.Models;
using Microsoft.AspNetCore.Identity;
using App.Controllers;
using Microsoft.AspNetCore.Mvc;
using App.Interfaces;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using App.Services;
namespace App.AuthRepository
{
	public class AuthRepo:IAuthRepo
	{
      
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;
        public readonly TokenService _token;
        public AuthRepo(IConfiguration config,ILogger<HomeController> logger,  UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,TokenService token)
		{
            
           
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _token = token;


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
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var user = await _userManager.FindByEmailAsync(userSignInForm.Email);
                var result = await _signInManager.PasswordSignInAsync(user.UserName, userSignInForm.Password, isPersistent: false, lockoutOnFailure: false);
                var token = _token.createToken(user);

              

       



            }
            catch (Exception e)
            {
                _logger.LogInformation($"User failed authorizate :{e}");
            }
          
        }
    }


}


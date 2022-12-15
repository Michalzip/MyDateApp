using System;
using App.Db;
using App.Models;
using Microsoft.AspNetCore.Identity;
using App.Controllers;
using Microsoft.AspNetCore.Mvc;
using App.Interfaces;
using App.Services;

namespace App.AuthRepository
{
    public class AuthRepo : IAuthRepo
    {

        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public readonly TokenService _token;

        public AuthRepo(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TokenService token)
        {


            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _token = token;

        }


        public async Task SaveUser(UserDetailDto userDetail)
        {

            try
            {

                var user = new ApplicationUser
                {
                    UserName = userDetail.UserName,
                    Email = userDetail.Email,
                    FirstName = userDetail.FirstName,
                    LastName = userDetail.LastName,
                    CreatedAt = DateTime.Now

                };

                await _userManager.CreateAsync(user, userDetail.Password);
            }

            catch (Exception e)
            {
                _logger.LogInformation($"Please Enter correct data :{e}");
            }
        }

        public async Task SignInUser(UserAuthModel userAuth)
        {

            try
            {
                var user = await _userManager.FindByEmailAsync(userAuth.Email);
                var result = await _signInManager.PasswordSignInAsync(user.UserName, userAuth.Password, isPersistent: false, lockoutOnFailure: false);
                var token = await _token.CreateToken(user);

                Console.WriteLine("token : " + token);
            }

            catch (Exception e)
            {
                _logger.LogInformation($"Invalid Email or password :{e}");
            }

        }
    }


}


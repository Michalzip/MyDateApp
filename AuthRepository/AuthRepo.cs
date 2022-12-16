using System;
using App.Db;
using App.Models;
using Microsoft.AspNetCore.Identity;
using App.Controllers;
using App.DTOs;
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


        public async Task SaveUser(RegisterDto model)
        {

            try
            {

                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CreatedAt = DateTime.Now

                };

                await _userManager.CreateAsync(user, model.Password);
            }

            catch (Exception e)
            {
                _logger.LogInformation($"Please Enter correct data :{e}");
            }
        }

        public async Task SignInUser(LoginDto model)
        {

            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);
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


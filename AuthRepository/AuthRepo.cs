using System;
using App.Db;
using App.Services;
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
        private IUserService _userService;

        public AuthRepo(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,IUserService userService)
		{
           
            _logger = logger;
            _userService = userService;

        }

        public async Task Register(IUserRegister model)
        {

            try
            {

                ApplicationUser userData = _userService.CreateUser(model);
                await _userService.SaveUser(userData);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"User is not created. Excepction :{e}");
            }
        }
    }


}


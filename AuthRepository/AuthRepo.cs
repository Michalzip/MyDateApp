using System;
using App.Db;
using App.Services;
using App.Models;
using Microsoft.AspNetCore.Identity;
using App.Controllers;
using Microsoft.AspNetCore.Mvc;
namespace App.AuthRepository
{
	public class AuthRepo:IAuthRepo
	{
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private IUserService _userService;

        public AuthRepo(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,IUserService userService)
		{
            _userManager = userManager;
            _logger = logger;
            _userService = userService;

        }

        public async Task Register(UserRegisterModel model)
        {

            var userData = _userService.SetUser(model);
            try
            {

               await _userManager.CreateAsync(userData);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"User is not created. Excepction :{e}");
            }
        }
    }
}


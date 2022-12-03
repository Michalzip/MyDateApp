using System;
using App.Models;
using App.Interfaces;
using Microsoft.AspNetCore.Identity;
namespace App.Services
{
	public class UserService:IUserService
	{


        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }



        public  ApplicationUser CreateUser(IUserRegister model)
		{

            String hashedPassword = HashPassword.CreatePasswordHash(model);

            var user = new ApplicationUser
            {
                UserName = model.Name,
                Email = model.Email,
                PasswordHash = hashedPassword

            };
            return user;

        }

        public async Task SaveUser(ApplicationUser user)
        {
            await _userManager.CreateAsync(user);
        }


    }
}


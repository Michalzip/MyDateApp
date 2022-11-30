using System;
using App.Models;

namespace App.Services
{
	public class UserService:IUserService
	{

		public  ApplicationUser SetUser(UserRegisterModel model)
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


    }
}


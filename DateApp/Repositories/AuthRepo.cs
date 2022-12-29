using Microsoft.AspNetCore.Identity;
using Api.Entities;


namespace App.AuthRepository
{
    public class AuthRepo :IAuthRepo
    {
  

        public  IdentityUser SetUserFromRegister(RegisterDto model)
        {

            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.UserName,
                PasswordHash = model.Password,
            };

            return user;

        }

        public IdentityUser SetUserFromLogin(LoginDto model)
        {
            var user = new IdentityUser {

                Email = model.Email,
                PasswordHash = model.Password

            };

            return user;
        }
    }

}









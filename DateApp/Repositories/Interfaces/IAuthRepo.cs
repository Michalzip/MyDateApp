using Microsoft.AspNetCore.Identity;

namespace App.Interfaces
{

 
    public interface IAuthRepo
    {

        IdentityUser SetUserFromRegister(RegisterDto model);
        IdentityUser SetUserFromLogin(LoginDto model);
      
    }

}


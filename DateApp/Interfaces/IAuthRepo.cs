using Microsoft.AspNetCore.Identity;

namespace App.Interfaces
{

 
    public interface IAuthRepo
    {

        Task<IdentityUser> Register(RegisterDto model);
        Task<IdentityUser> Login(LoginDto model);
      
    }

}


using Microsoft.AspNetCore.Identity;

namespace Api.Repositories.Interfaces
{

 
    public interface IAuthRepository
    {

        Task<IdentityResult> RegisterUser(RegisterDto model);
        Task<SignInResult> LoginUser(LoginDto model);


    }

}


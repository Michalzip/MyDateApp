using Microsoft.AspNetCore.Identity;
using Server.Models;
namespace Api.Repositories.Interfaces
{


    public interface IAuthRepository
    {

        Task<IdentityResult> RegisterUser(ApplicationUser model);
        Task<SignInResult> LoginUser(ApplicationUser model);


    }

}


using System;
namespace Api.Services.Interfaces
{
	public interface IAuthService
	{
        Task<IdentityResult> RegisterUser(RegisterDto model);
        Task<SignInResult> LoginUser(LoginDto model);
     

    }
}


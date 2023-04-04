namespace IdentityServer.Application.Services.Interfaces
{
    public interface IAuthService
    {
          public  Task<IdentityResult> SignUp(string email,string name,string password);
          public  Task<SignInResult> SignIn(string name,string password);

    }
}
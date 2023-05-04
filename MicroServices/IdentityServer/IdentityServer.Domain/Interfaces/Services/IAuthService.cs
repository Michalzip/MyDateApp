namespace IdentityServer.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<IdentityResult> SignUp(string email, string username, string password);
        public Task<SignInResult> SignIn(string username, string password);
        public void LogoutPublisher();
    }
}
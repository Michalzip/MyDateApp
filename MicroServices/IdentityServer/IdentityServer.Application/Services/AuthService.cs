
using IdentityServer.Application.Functions.Commands;
using IdentityServer.Application.Services.Interfaces;
namespace IdentityServer.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMediator _mediator;

        public AuthService(IMediator mediator)
        {

            _mediator = mediator;

        }

        public async Task<IdentityResult> SignUp(string email, string name, string password)
        {

            return await _mediator.Send(new CreateUserCommand { Email = email, UserName = name, Password = password });

        }

        public async Task<SignInResult> SignIn(string name, string password)
        {

            return await _mediator.Send(new AuthenticateUserCommand { UserName = name, Password = password });

        }
    }
}
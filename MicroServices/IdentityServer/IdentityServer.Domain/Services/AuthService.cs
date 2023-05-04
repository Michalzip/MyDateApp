using IdentityServer.Domain.Functions.AuthenticationFunctions.Commands;
using IdentityServer.Domain.Interfaces.Messages;
using IdentityServer.Domain.Functions.UserFunctions.Commands;
using Shared.Abstraction.Exceptions;
using IdentityServer.Domain.Functions.UserFunctions.Queries;


namespace IdentityServer.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMediator _mediator;
        private readonly IMessagePublisher _publisher;

        public AuthService(IMediator mediator, IMessagePublisher publisher)
        {
            _mediator = mediator;
            _publisher = publisher;
        }

        public async Task<IdentityResult> SignUp(string email, string username, string password)
        {
            var result = await _mediator.Send(new CreateUserCommand { Email = email, UserName = username, Password = password });

            if (!result.Succeeded) throw new FailedOperationException("failed to sign up user");

            return result;
        }

        public async Task<SignInResult> SignIn(string username, string password)
        {

            var user = await _mediator.Send(new GetUserByNameQuery { UserName = username });

            if (user == null) throw new NotFoundException("user not found");

            var result = await _mediator.Send(new AuthenticateUserCommand { User = user, UserName = username, Password = password });

            if (!result.Succeeded) throw new FailedOperationException("failed to authenticate user");

            _publisher.LoggedInUserPublisher(user.Id, username);

            return result;
        }

        public void LogoutPublisher()
        {
            _publisher.LogoutUserPublisher();
        }
    }
}
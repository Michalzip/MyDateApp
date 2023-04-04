
namespace IdentityServer.Application.Functions.Commands
{
    public class AuthenticateUserCommand : IRequest<SignInResult>
    {


        public string? UserName { get; set; }
        public string? Password { get; set; }


        public class AuthenticateUser : IRequestHandler<AuthenticateUserCommand, SignInResult>
        {
            private readonly SignInManager<ApplicationUser> _signInManager;

            public AuthenticateUser(SignInManager<ApplicationUser> signInManager)
            {
                _signInManager = signInManager;
            }

            async Task<SignInResult> IRequestHandler<AuthenticateUserCommand, SignInResult>.Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
            {
                return await _signInManager.PasswordSignInAsync(request.UserName, request.Password, isPersistent: false, lockoutOnFailure: false);

            }
        }
    }

}
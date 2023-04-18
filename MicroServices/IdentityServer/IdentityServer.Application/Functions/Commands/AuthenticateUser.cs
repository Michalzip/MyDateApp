
namespace IdentityServer.Application.Functions.Commands
{
    public class AuthenticateUserCommand : IRequest<SignInResult>
    {


        public string? UserName { get; set; }
        public string? Password { get; set; }


        public class AuthenticateUser : IRequestHandler<AuthenticateUserCommand, SignInResult>
        {
            private readonly SignInManager<ApplicationUser> _signInManager;
            private readonly UserManager<ApplicationUser> _userManager;

            public AuthenticateUser(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
            {
                _signInManager = signInManager;
                _userManager = userManager;
            }

            async Task<SignInResult> IRequestHandler<AuthenticateUserCommand, SignInResult>.Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
            {

                var user = await _userManager.FindByNameAsync(request.UserName);

                return await _signInManager.PasswordSignInAsync(user, request.Password, isPersistent: false, lockoutOnFailure: false);



            }
        }
    }

}
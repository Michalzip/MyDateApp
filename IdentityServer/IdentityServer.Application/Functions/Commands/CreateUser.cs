
namespace IdentityServer.Application.Functions.Commands
{
    public class CreateUserCommand : IRequest<IdentityResult>
    {

        public String? Email { get; set; }
        public String? UserName { get; set; }
        public String? Password { get; set; }


        public class CreateUser : IRequestHandler<CreateUserCommand, IdentityResult>
        {
            private readonly UserManager<ApplicationUser> _userManager;

            public CreateUser(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }



            async Task<IdentityResult> IRequestHandler<CreateUserCommand, IdentityResult>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                return await _userManager.CreateAsync(new ApplicationUser { Email = request.Email, UserName = request.UserName, PasswordHash = request.Password });

            }
        }

    }
}
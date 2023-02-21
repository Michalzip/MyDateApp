
namespace Server.Functions.UserFunctions.Commands
{
    public class CreateUserCommand : IRequest<IdentityResult>
    {

        public ApplicationUser? User { get; set; }


        public class CreateUser : IRequestHandler<CreateUserCommand, IdentityResult>
        {
            private readonly UserManager<ApplicationUser> _userManager;

            public CreateUser(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }



            async Task<IdentityResult> IRequestHandler<CreateUserCommand, IdentityResult>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                return await _userManager.CreateAsync(request.User, request.User.PasswordHash);

            }
        }


    }
}
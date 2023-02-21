

namespace Server.Functions.UserFunctions.Commands
{


    public class CreateVipUserCommand : IRequest<IdentityResult>
    {

        public ApplicationUser? User { get; set; }

        public class CreateVipUser : IRequestHandler<CreateVipUserCommand, IdentityResult>
        {
            private readonly UserManager<ApplicationUser> _userManager;

            public CreateVipUser(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }



            async Task<IdentityResult> IRequestHandler<CreateVipUserCommand, IdentityResult>.Handle(CreateVipUserCommand request, CancellationToken cancellationToken)
            {
                request.User.isvVip = true;

                return await _userManager.UpdateAsync(request.User);



            }
        }


    }
}
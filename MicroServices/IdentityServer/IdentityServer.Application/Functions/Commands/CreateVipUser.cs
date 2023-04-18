

namespace IdentityServer.Application.Functions.Commands
{


    public class CreateVipUserCommand : IRequest<IdentityResult>
    {

        public String? UserName { get; set; }

        public class CreateVipUser : IRequestHandler<CreateVipUserCommand, IdentityResult>
        {
            private readonly UserManager<ApplicationUser> _userManager;

            public CreateVipUser(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }



            async Task<IdentityResult> IRequestHandler<CreateVipUserCommand, IdentityResult>.Handle(CreateVipUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                user.isvVip = true;

                return await _userManager.UpdateAsync(user);
            }
        }


    }
}
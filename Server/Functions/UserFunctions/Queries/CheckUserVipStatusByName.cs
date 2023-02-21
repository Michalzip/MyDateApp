
namespace Server.Functions.UserFunctions.Queries
{

    public class CheckUserVipStatusByNameQuery : IRequest<bool>
    {

        public string? UserName { get; set; }



        public class CheckUserVipStatusByName : IRequestHandler<CheckUserVipStatusByNameQuery, bool>
        {

            private readonly UserManager<ApplicationUser> _userManager;

            public CheckUserVipStatusByName(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }

            async Task<bool> IRequestHandler<CheckUserVipStatusByNameQuery, bool>.Handle(CheckUserVipStatusByNameQuery request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                return user.isvVip ? true : false;

            }
        }
    }
}
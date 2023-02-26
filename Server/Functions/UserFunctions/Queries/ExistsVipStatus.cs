

namespace Server.Functions.UserFunctions.Queries
{
    public class ExistsVipStatusQuery : IRequest<bool>
    {
        public string? UserName { get; set; }

        public class ExistsVipStatus : IRequestHandler<ExistsVipStatusQuery, bool>
        {

            private readonly UserManager<ApplicationUser> _userManager;

            public ExistsVipStatus(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }

            async Task<bool> IRequestHandler<ExistsVipStatusQuery, bool>.Handle(ExistsVipStatusQuery request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                return user.isvVip ? true : false;

            }
        }
    }
}
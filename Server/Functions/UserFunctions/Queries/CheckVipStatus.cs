

namespace Server.Functions.UserFunctions.Queries
{
    public class CheckVipStatusQuery : IRequest<bool>
    {
        public string? UserName { get; set; }

        public class ExistsVipStatus : IRequestHandler<CheckVipStatusQuery, bool>
        {

            private readonly UserManager<ApplicationUser> _userManager;

            public ExistsVipStatus(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }

            async Task<bool> IRequestHandler<CheckVipStatusQuery, bool>.Handle(CheckVipStatusQuery request, CancellationToken cancellationToken)
            {
                var user = _userManager.Users.Where(u => u.isvVip == true && u.UserName == request.UserName).FirstOrDefault();

                if (user == null) return false;

                return user.isvVip ? true : false;

            }
        }
    }
};
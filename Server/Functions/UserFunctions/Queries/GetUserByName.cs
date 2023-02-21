

namespace Server.Functions.UserFunctions.Queries
{
    public class GetUserByNameQuery : IRequest<ApplicationUser>
    {

        public string? UserName { get; set; }

        public class GetUserByName : IRequestHandler<GetUserByNameQuery, ApplicationUser>
        {
            private readonly UserManager<ApplicationUser> _userManager;

            public GetUserByName(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }

            async Task<ApplicationUser> IRequestHandler<GetUserByNameQuery, ApplicationUser>.Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
            {
              return  await _userManager.FindByNameAsync(request.UserName);
                
            }
        }
    }
}
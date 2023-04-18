

namespace IdentityServer.Application.Functions.Queries
{
    public class GetVipStatusQuery:IRequest<bool>
    {
        public string? UserName { get; set; }
        public class GetVipStatus:  IRequestHandler<GetVipStatusQuery, bool>
        {

             private readonly UserManager<ApplicationUser> _userManager;

              public GetVipStatus(UserManager<ApplicationUser> userManager)
             {
                     _userManager = userManager;
             }


           async  Task<bool> IRequestHandler<GetVipStatusQuery, bool>.Handle(GetVipStatusQuery request, CancellationToken cancellationToken)
            {
             
                var user =  await _userManager.FindByNameAsync(request.UserName);

                if(user.isvVip) return true;

                return false;
            }
        }
       
        
    }
}
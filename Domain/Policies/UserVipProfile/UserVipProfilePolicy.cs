using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using Server.Services.Interface;
using Domain.Interfaces.Repositories;
namespace Domain.Policies.UserVipProfile
{
    


        public class RequirementVipHandler : AuthorizationHandler<UserVipProfileRequirement>
        {

            private readonly IUserService _userService;

            public RequirementVipHandler(IUserService userService)
            {
                _userService = userService;

            }

            protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserVipProfileRequirement requirement)
            {
                var currentUserName = context.User.Identity.Name;

                var vipUser = await _userService.CheckVipStatus(currentUserName);

                if (vipUser)
                context.Succeed(requirement);

                await Task.CompletedTask;



            }
        }



    public class UserVipProfileRequirement : IAuthorizationRequirement
    {

    }


}

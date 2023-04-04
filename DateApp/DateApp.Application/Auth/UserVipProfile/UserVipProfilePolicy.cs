
using IdentityServer.Application.Services.Interfaces;


namespace DateApp.Application.Auth.UserVipProfile
{
    public class RequirementVipHandler : AuthorizationHandler<UserVipProfilePolicy>
    {
        private readonly IDentityUserService _userIdentitieService;

        public RequirementVipHandler(IDentityUserService userIdentitieService)
        {
            _userIdentitieService = userIdentitieService;

        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserVipProfilePolicy requirement)
        {
            var currentUserName = context.User.Identity.Name;

            var vipUser = await _userIdentitieService.GetVipStatus(currentUserName);

            if (vipUser)
                context.Succeed(requirement);

            await Task.CompletedTask;


        }
    }



    public class UserVipProfilePolicy : IAuthorizationRequirement
    {

    }
}
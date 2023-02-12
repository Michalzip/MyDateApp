using System;
using Server.data;

namespace Api.Policies.UserVipProfile
{
	public class RequirementVipHandler:AuthorizationHandler<UserVipProfileRequirement>
	{

        private readonly ApplicationDbContext _identityContext;

        public RequirementVipHandler(ApplicationDbContext identityContext)
		{
            _identityContext = identityContext;

        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserVipProfileRequirement requirement)
        {
            var currentUserName = context.User.Identity.Name;

            var result = _identityContext.Users.Where(u => u.isvVip == true && u.UserName == currentUserName).FirstOrDefault();

            if (result != null) context.Succeed(requirement);

            await Task.CompletedTask;


     
        }
    }


    public class UserVipProfileRequirement : IAuthorizationRequirement
    {

    }
}


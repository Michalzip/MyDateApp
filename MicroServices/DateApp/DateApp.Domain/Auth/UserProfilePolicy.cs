namespace DateApp.Domain.Auth
{
    public class RequirementHandler : AuthorizationHandler<UserProfilePolicy>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public RequirementHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserProfilePolicy requirement)
        {
            var currentUserName = context.User.Identity.Name;

            var userProfile = await _userProfileRepository.getUserProfileByName(currentUserName);

            if (userProfile != null) context.Succeed(requirement);

            await Task.CompletedTask;
        }
    }

    public class UserProfilePolicy : IAuthorizationRequirement
    {
    }
}
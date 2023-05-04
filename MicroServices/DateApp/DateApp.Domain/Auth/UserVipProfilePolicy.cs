using DateApp.Domain.Interfaces.Messages;

namespace DateApp.Domain.Auth
{

    public class RequirementVipHandler : AuthorizationHandler<UserVipProfilePolicy>
    {
        private readonly IRpcClient _rpcClient;

        public RequirementVipHandler(IRpcClient rpcClient)
        {
            _rpcClient = rpcClient;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserVipProfilePolicy requirement)
        {
            var currentUserName = context.User?.Identity?.Name;

            var vipUser = await _rpcClient.VipStatusPublisher(currentUserName);

            if (vipUser) context.Succeed(requirement);

            await Task.CompletedTask;
        }
    }

    public class UserVipProfilePolicy : IAuthorizationRequirement
    {
    }
}
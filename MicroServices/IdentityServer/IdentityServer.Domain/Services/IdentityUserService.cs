using Shared.Abstraction.Exceptions;
using IdentityServer.Domain.Functions.UserFunctions.Queries;
using IdentityServer.Domain.Functions.VipFunctions.Commands;

namespace IdentityServer.Application.Services
{
    public class IdentityUserService : IDentityUserService
    {
        private readonly IMediator _mediator;
        public IdentityUserService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ApplicationUser> GetIdentityUserByName(string name)
        {
            var user = await _mediator.Send(new GetUserByNameQuery { UserName = name });

            if (user == null) throw new NotFoundException("user not found");

            return user;
        }

        public async Task<IdentityResult> CreateVipUser(string name)
        {
            var user = await _mediator.Send(new GetUserByNameQuery { UserName = name });

            if (user == null) throw new NotFoundException("user not found");

            if (user.isvVip) throw new FailedOperationException("vip already exists");

            var result = await _mediator.Send(new CreateVipUserCommand { User = user });

            if (!result.Succeeded) throw new FailedOperationException("failed to create vip user");

            return result;
        }
    }
}
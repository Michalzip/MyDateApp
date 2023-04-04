
using IdentityServer.Application.Functions.Queries;
using  IdentityServer.Application.Functions.Commands;
using IdentityServer.Application.Services.Interfaces;

namespace IdentityServer.Application.Services
{
    public class IdentityUserService: IDentityUserService
    {
            private readonly IMediator _mediator;
            public  IdentityUserService(IMediator mediator){

            _mediator = mediator;

         }

         public async Task<ApplicationUser> GetIdentityUserByName(string name){

            return await _mediator.Send(new GetUserByNameQuery{UserName = name});

         }

           public async Task<IdentityResult> CreateVipUser(string name){

            return await _mediator.Send(new CreateVipUserCommand{UserName = name});

         }

           public async Task<bool> GetVipStatus(string name){

            return await _mediator.Send(new GetVipStatusQuery{UserName = name});

         }


    }
}
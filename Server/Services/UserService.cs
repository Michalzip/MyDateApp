using Server.Functions.UserFunctions.Commands;
using Server.Functions.UserFunctions.Queries;
using Server.Services.Interface;

namespace Server.Services
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;
        public UserService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IdentityResult> CreateIdentityUser(string email, string username, string password)
        {

            var applicationUser = new ApplicationUser
            {
                Email = email,
                UserName = username,
                PasswordHash = password,
            };

            var newUser = new CreateUserCommand
            {
                User = applicationUser
            };

            return await _mediator.Send(newUser);

        }

        public async Task<IdentityResult> CreateVipIdentityUser(string username)
        {

            var user = await _mediator.Send(new GetUserByNameQuery { UserName = username });

            return await _mediator.Send(new CreateVipUserCommand { User = user });
        }

        public async Task<SignInResult> AuthenticateIdentityUser(string email, string password)
        {

            var applicationUser = await _mediator.Send(new GetUserByEmailQuery { Email = email });

            if (applicationUser == null) return null;


            return await _mediator.Send(new AuthenticateUserCommand { Name = applicationUser.UserName, Password = password });
        }

        public async Task<ApplicationUser> GetIdentityUser(string username)
        {


            return await _mediator.Send(new GetUserByNameQuery { UserName = username });
        }


        public async Task<bool> CheckVipStatus(string username)
        {

            return await _mediator.Send(new CheckVipStatusQuery { UserName = username });
        }


    }
}
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
            var getUserByName = new GetUserByNameQuery
            {
                UserName = username
            };

            var user = await _mediator.Send(getUserByName);

            var createVip = new CreateVipUserCommand
            {
                User = user
            };

            return await _mediator.Send(createVip);
        }

        public async Task<SignInResult> AuthenticateIdentityUser(string email, string password)
        {

            var getUserByEmailQuery = new GetUserByEmailQuery
            {
                Email = email

            };


            var applicationUser = await _mediator.Send(getUserByEmailQuery);

            if (applicationUser == null) return null;

            var authenticateUser = new AuthenticateUserCommand
            {
                Name = applicationUser.UserName,
                Password = password

            };

            return await _mediator.Send(authenticateUser);
        }

        public async Task<ApplicationUser> GetIdentityUser(string username)
        {

            var getUserByNameQuery = new GetUserByNameQuery
            {
                UserName = username
            };

            return await _mediator.Send(getUserByNameQuery);
        }


    }
}
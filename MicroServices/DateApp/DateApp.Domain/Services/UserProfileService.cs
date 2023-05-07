
using Microsoft.Extensions.Caching.Memory;
using Shared.Jwt;
using DateApp.Domain.Functions.UserFunctions.Commands;

namespace DateApp.Domain.Services
{
    internal class UserProfileService : IUserProfileService
    {
        private readonly IMediator _mediator;
        private readonly ITokenService _tokenService;
        private readonly IMemoryCache _cache;
        public UserProfileService(IMediator mediator, ITokenService tokenService, IMemoryCache cache)
        {
            _mediator = mediator;
            _tokenService = tokenService;
            _cache = cache;
        }

        public async Task CreateUserProfile(string firstName, string lastName, string photoUrl)
        {

            var token = _cache.Get<string>("jwtToken");

            Console.WriteLine(token);

            if (string.IsNullOrEmpty(token)) throw new NotFoundException("authorize token not found, please try sign in again"); ;

            var identityUser = _tokenService.GetTokenData(token);

            var existUserProfile = await _mediator.Send(new CheckUserProfileExistenceQuery { Id = identityUser.Id });

            if (existUserProfile) throw new AlreadyExistsException("userProfile with this user is currently created");


            if (identityUser == null) throw new NotFoundException("User does not exist");

            var result = await _mediator.Send(new CreateUserCommand
            {
                User = new UserProfile
                {
                    Id = identityUser.Id,
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = identityUser.UserName,
                    PhotoUrl = photoUrl,
                }
            });

            if (result == 0) throw new FailedOperationException("Failed to create user");
        }

        public async Task<UserProfile> GetUserProfile(string username)
        {
            var userProfile = await _mediator.Send(new GetUserByNameQuery { UserName = username });

            if (userProfile == null) throw new NotFoundException("User does not exist");

            return userProfile;
        }
    }
}
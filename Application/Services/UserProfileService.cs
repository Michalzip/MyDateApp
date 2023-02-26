using DateApp.Functions.UserFunctions.Commands;
using Domain.Interfaces.Services;
namespace DateApp.Services
{
    public class UserProfileService : IUserProfileService
    {

        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserProfileService(IMediator mediator, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<int> CreateUserProfile(string firstName, string lastName, string photoUrl)
        {
            var sourceUserName = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            var identityUser = await _userService.GetIdentityUser(sourceUserName);



            var userData = new UserProfile
            {

                Id = identityUser.Id,
                FirstName = firstName,
                LastName = lastName,
                UserName = identityUser.UserName,
                PhotoUrl = photoUrl,


            };

            var createUserCommand = new CreateUserCommand
            {
                User = userData
            };

            return await _mediator.Send(createUserCommand);

        }


        public async Task<UserProfile> GetUserProfile(string username)
        {

            var getUserByNameQuery = new GetUserByNameQuery
            {
                UserName = username
            };

            return await _mediator.Send(getUserByNameQuery);

        }

    }
}
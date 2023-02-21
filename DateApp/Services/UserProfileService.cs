using DateApp.Functions.UserFunctions.Commands;

namespace DateApp.Services
{
    public class UserProfileService
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


        public async Task<int> CreateUserProfile(UserCreateProfileDto user)
        {
            var sourceUserName = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            var identityUser = await _userService.GetIdentityUser(sourceUserName);



            var userData = new UserProfile
            {


                Id = identityUser.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = identityUser.UserName,
                PhotoUrl = user.PhotoUrl,


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
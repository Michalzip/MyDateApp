using Application.Functions.UserFunctions.Commands;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class UserProfileService : IUserProfileService
    {

        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public UserProfileService(IMediator mediator, IUserService userService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mediator = mediator;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;



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


            return await _mediator.Send(new CreateUserCommand { User = userData });

        }


        public async Task<UserProfileDto> GetUserProfile(string username)
        {

            var userProfile =  await _mediator.Send(new GetUserByNameQuery { UserName = username });

            return _mapper.Map<UserProfile, UserProfileDto>(userProfile);
        }

    }
}
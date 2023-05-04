
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("dateapp/[controller]")]

    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileService _userProfile;

        public UserProfileController(IUserProfileService userProfile, IMapper mapper)
        {
            _userProfile = userProfile;
            _mapper = mapper;
        }

        [HttpGet("get-user-by-name")]
        public async Task<ActionResult> GetUser(string username)
        {
            Console.WriteLine(User.GetUsername());

            var user = await _userProfile.GetUserProfile(username);

            if (user == null) return NotFound("Not Found User");

            var userProfileDto = _mapper.Map<UserProfile, UserProfileDto>(user);

            return Ok(userProfileDto);
        }

        [HttpPost("create-user-profile")]
        public async Task<ActionResult> CreateUserProfile(UserCreateProfileDto userData)
        {
            await _userProfile.CreateUserProfile(userData.FirstName, userData.LastName, userData.PhotoUrl);

            return Ok("UserProfile created successfully");
        }
    }
}

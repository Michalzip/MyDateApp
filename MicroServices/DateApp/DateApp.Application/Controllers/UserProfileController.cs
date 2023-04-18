
using Microsoft.AspNetCore.Mvc;
// using DateApp.Services;
using Application.Functions.UserFunctions.Queries;
namespace Application.Controllers
{
    [Route("dateapp/[controller]")]
    // [Authorize]
    public class UserProfileController : Controller
    {

        private readonly IUserProfileService _userProfile;

        public UserProfileController(IUserProfileService userProfile)
        {
            _userProfile = userProfile;
        }


        [HttpGet("get-user-by-name")]
        public async Task<ActionResult<UserProfileDto>> GetUser(string username)
        {
            // string usernamea = ;
            // Console.WriteLine("awdawdawdaw" + usernamea);

            var user = await _userProfile.GetUserProfile(username);

            if (user == null) return NotFound("Not Found User");



            return Ok(user);
        }


        [HttpPost("create-user-profile")]
        public async Task<ActionResult> CreateUserProfile(UserCreateProfileDto userData)
        {

            var result = await _userProfile.CreateUserProfile(userData.FirstName, userData.LastName, userData.PhotoUrl);

            if (result > 0) return Ok("UserProfile created successfully");

            return BadRequest("Failed To Create UserProfile");

        }
    }
}

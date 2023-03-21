using MediatR;
using Microsoft.AspNetCore.Mvc;
// using DateApp.Services;
using Application.Functions.UserFunctions.Queries;
namespace Application.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private readonly IUserProfileService _userProfile;

        public UserController(IUserProfileService userProfile)
        {
            _userProfile = userProfile;
        }


        [HttpGet("get-user-by-name")]
        public async Task<ActionResult<UserProfileDto>> GetUser(string username)
        {

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


using Microsoft.AspNetCore.Mvc;
using DateApp.Services;

namespace App.Controllers
{
    [Authorize]
    public class UserController : Controller
    {



        private readonly UserProfileService _userProfileService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, UserProfileService userProfileService)
        {

            _userProfileService = userProfileService;
            _mapper = mapper;
        }


        [HttpGet("get-user-by-name")]
        public async Task<ActionResult<UserProfileDto>> GetUser(string username)
        {

            var user = await _userProfileService.GetUserProfile(username);

            if (user != null) return Ok(_mapper.Map<UserProfile, UserProfileDto>(user));

            return NotFound("Not Found User");
        }




        [HttpPost("create-user-profile")]
        public async Task<ActionResult> CreateUserProfile(UserCreateProfileDto userData)
        {

            var result = await _userProfileService.CreateUserProfile(userData);

            if (result > 0) return Ok("UserProfile created successfully");

            return BadRequest("Failed To Create UserProfile");


        }

    }
}


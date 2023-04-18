using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IdentityServer.Application.Services.Interfaces;
using Shared.Abstraction.Extensions;

namespace IdentityServer.Application.Controllers
{
    //[Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IDentityUserService _identityUserService;


        public UserController(ILogger<UserController> logger, IDentityUserService identityUserService)
        {
            _logger = logger;
            _identityUserService = identityUserService;


        }



        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(string UserName)
        {

            var result = await _identityUserService.GetIdentityUserByName(UserName);

            if (result != null) return Ok(result);

            return Unauthorized();

        }

        [HttpGet("get-logged-in-user-name")]
        public string GetLoggedInUserName()
        {

            string username = User.GetUsername(); //!< -get current logged in userName
            return username; //!< -this invoke error in rpc Server and Client .
            // return "JAREK";

        }






        [HttpGet("GetVipStatus")]
        public async Task<ActionResult> GetVipStatus(string UserName)
        {

            var result = await _identityUserService.GetVipStatus(UserName);

            if (result) return Ok("User Logout");

            return NotFound("VIP status not found");

        }

        [HttpPost("CreateVipUser")]
        public async Task<IActionResult> CreateVipUser(string UserName)
        {

            var result = await _identityUserService.CreateVipUser(UserName);

            if (result.Succeeded) return Ok("user logged Successfully");

            return Unauthorized();
        }

    }
}
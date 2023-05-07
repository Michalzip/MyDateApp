
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using IdentityServer.Domain.Interfaces.Services;
using IdentityServer.Application.DTOs;

namespace IdentityServer.Application.Controllers
{
    [Route("identityserver/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SignUpDto user)
        {
            await _authService.SignUp(user.Email, user.UserName, user.Password);

            return Ok("user sign up Successfully");
        }


        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignInDto user)
        {
            if (User.Identity.IsAuthenticated) return BadRequest("user already logged in.");

            await _authService.SignIn(user.UserName, user.Password);

            return Ok("user logged Successfully");
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            _authService.LogoutPublisher();

            return Ok("User Logout");
        }
    }
}
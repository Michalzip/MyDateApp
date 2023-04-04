
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using IdentityServer.Application.Services.Interfaces;
using IdentityServer.Application.DTOs;

namespace IdentityServer.Application.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDto user)
        {

            var result = await _authService.SignUp(user.Email, user.UserName, user.Password);

            if (result.Succeeded) return Ok(result);

            return Unauthorized();

        }

        [HttpPost("Logout")]
        public async Task<ActionResult> Logout()
        {

            //return NotFound();
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            return Ok("User Logout");

        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInDto user)
        {

            var result = await _authService.SignIn(user.Email, user.Password);

            if (result == null) return BadRequest("NOT found Email");

            if (result.Succeeded) return Ok("user logged Successfully");

            return Unauthorized();
        }
    }
}
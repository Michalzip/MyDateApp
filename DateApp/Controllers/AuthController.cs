using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Server.Models;

namespace App.Controllers;

public class AuthController : Controller
{

    private readonly IAuthRepository _authRepo;


    public AuthController(IAuthRepository authRepo)
    {

        _authRepo = authRepo;

    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterDto user)
    {


        var applicationUser = new ApplicationUser
        {
            Email = user.Email,
            UserName = user.UserName,
            PasswordHash = user.Password,
        };


        var result = await _authRepo.RegisterUser(applicationUser);

        if (result.Succeeded) return Ok(result);

        return Unauthorized();

    }

    [HttpPost("Logout")]
    public async Task<ActionResult> Logout()
    {

        await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

        return Ok("User Logout");

    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto user)
    {

        var applicationUser = new ApplicationUser
        {

            Email = user.Email,
            PasswordHash = user.Password

        };

        var result = await _authRepo.LoginUser(applicationUser);

        if (result.Succeeded) return Ok(result);

        return Unauthorized();
    }




}


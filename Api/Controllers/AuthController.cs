using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;


namespace App.Controllers;

public class AuthController : Controller
{

    private readonly IUserService _userService;


    public AuthController(IUserService userService)
    {

        _userService = userService;

    }

    [HttpPost("create-user")]
    public async Task<IActionResult> Register(RegisterDto user)
    {

        var result = await _userService.CreateIdentityUser(user.Email, user.UserName, user.Password);

        if (result.Succeeded) return Ok(result);

        return Unauthorized();

    }

    [HttpPost("unauthenticate-user")]
    public async Task<ActionResult> Logout()
    {

        await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

        return Ok("User Logout");

    }

    [HttpPost("authenticate-user")]
    public async Task<IActionResult> Login(LoginDto user)
    {

        var result = await _userService.AuthenticateIdentityUser(user.Email, user.Password);

        if (result == null) return BadRequest("NOT found Email");

        if (result.Succeeded) return Ok("user logged Successfully");

        return Unauthorized();
    }




}


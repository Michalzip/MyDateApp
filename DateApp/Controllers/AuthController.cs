using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace App.Controllers;

public class AuthController : Controller
{

    private readonly IAuthRepository _authRepo;


    public AuthController(IAuthRepository authRepo)
    {

        _authRepo = authRepo;

    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterDto model)
    {

        var result = await _authRepo.RegisterUser(model);

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
    public async Task<IActionResult> Login(LoginDto model)
    {

        var result = await _authRepo.LoginUser(model);

        if (result.Succeeded) return Ok(result);

        return Unauthorized();
    }




}


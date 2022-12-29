
namespace App.Controllers;

using Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Server;

public class AuthController : Controller
{

    private readonly IAuthService _authService;
 

    public AuthController(IAuthService authService)
    {

        _authService = authService;

    }


    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterDto model)
    {

        var result  =   await _authService.RegisterUser(model);

        if (result.Succeeded) return Ok(result);

        return Unauthorized();

    }



    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto model)
    {

        var result  = await _authService.LoginUser(model);

        if (result.Succeeded) return Ok(result);

        return Unauthorized();
    }

    

        public async Task<IActionResult> LoginSuccess()
    {

        return View();

    }

}


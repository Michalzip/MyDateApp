
namespace App.Controllers;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Server;

public class AuthController : Controller
{

    private readonly IAuthRepo _authRepo;
 

    public AuthController(IAuthRepo authRepo)
    {

        _authRepo = authRepo;

    }


    [HttpPost("Register")]
    public async Task<ActionResult> Register(RegisterDto model)
    {

        var user = await _authRepo.Register(model);

        return Ok(user);

    }



    [HttpPost("Login")]
    public async Task<ActionResult> Login(LoginDto model)
    {

       var user =  await _authRepo.Login(model);

        return Ok(user);
    }


    public async Task<IActionResult> LoginSuccess()
    {

        return View();

    }

}



namespace App.Controllers;


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
        try
        {
            var user =  await _authRepo.Register(model);
        
            return Ok(user);
        }

        catch(Exception message)
        {

            return Unauthorized(message);
        }

    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login(LoginDto model)
    {
        try {

            var user  = await _authRepo.Login(model);

            return Ok(user);
        }

        catch(Exception message) {

            return Unauthorized(message);
        }
      

    }




    public async Task<IActionResult> LoginSuccess()
    {

        return View();

    }

}


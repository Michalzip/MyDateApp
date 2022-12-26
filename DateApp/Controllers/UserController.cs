using Microsoft.AspNetCore.Mvc;
namespace App.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        //janek@gmail.com
        //Janek141#21
        [HttpGet("GetUser")]
        [Authorize]
        public async Task GetUser()
        {

        }


    
    }
}


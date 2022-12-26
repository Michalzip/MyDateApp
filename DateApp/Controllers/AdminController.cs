
using Microsoft.AspNetCore.Mvc;
namespace App.Controllers
{
    public class AdminController : Controller
    {
        //email Adam2141@gmail.com
        //Pass JFwdadhawd#2151
        [Authorize(Policy = "Admin")]
        [HttpGet("getAdmin")]
        public async Task GetAdmin()
        {
            Console.WriteLine("hello admin");
        }
       
    }
}




using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class AdminController : Controller
    {

        [Authorize(Policy = "Admin")]

        [HttpGet("getAdmin")]
        public async Task GetAdmin()
        {
            Console.WriteLine("hello admin");
        }

    }
}


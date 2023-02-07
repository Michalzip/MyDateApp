

using Microsoft.AspNetCore.Mvc;
using DateApp.Helpers;
namespace App.Controllers
{

    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {



        [HttpGet("getAdmin")]
        public async Task GetSuccessPayments([FromQuery] PaginationParams w)
        {
            Console.WriteLine("hello admin");
        }

    }
}


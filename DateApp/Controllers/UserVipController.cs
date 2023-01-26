using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Authorize(Policy = "UserVipProfile")]
    public class UserVipController : Controller
    {

        [HttpGet("checkIfYouAreVip")]
        public ActionResult HelloVip()
        {
           return Ok("hello i am a vip");
        }

    }
}


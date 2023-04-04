
using Microsoft.AspNetCore.Mvc;


namespace Application.Controllers
{
    [Authorize(Policy = "UserVipProfile")]
    public class UserVipController : Controller
    {

        [HttpGet("vip")]
        public ActionResult HelloVip()
        {
            return Ok("hello i am a vip");
        }

    }
}


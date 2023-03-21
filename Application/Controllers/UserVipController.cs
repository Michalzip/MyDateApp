
using Microsoft.AspNetCore.Mvc;


namespace Application.Controllers
{
    [Authorize(Policy = "UserVipProfile")]
    public class UserVipController : Controller
    {

        [HttpGet("check-vip-status")]
        public ActionResult HelloVip()
        {
            return Ok("hello i am a vip");
        }

    }
}


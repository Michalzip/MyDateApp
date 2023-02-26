
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
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


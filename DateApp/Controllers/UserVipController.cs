
using Microsoft.AspNetCore.Mvc;


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


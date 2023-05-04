
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("dateapp/[controller]")]
    [Authorize(Policy = "UserVipProfile")]
    public class UserVipController : Controller
    {
        [HttpGet("vip")]
        public ActionResult HelloVip()
        {
            return Ok("Welcom in vip room");
        }
    }
}


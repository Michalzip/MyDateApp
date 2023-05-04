using System.Net;
using Microsoft.AspNetCore.Mvc;
using IdentityServer.Domain.Interfaces.Services;
using Shared.Abstraction.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace IdentityServer.Application.Controllers
{
    [Route("identityserver/[controller]")]
    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        private readonly IDentityUserService _identityUserService;

        public AdminController(IDentityUserService identityUserService)
        {
            _identityUserService = identityUserService;
        }

        [HttpGet("get-user")]
        public async Task<IActionResult> GetUser(string UserName)
        {
            var result = await _identityUserService.GetIdentityUserByName(UserName);

            return Ok(result);
        }

        [HttpPost("create-vip-user")]
        public async Task<IActionResult> CreateVipUser(string UserName)
        {
            await _identityUserService.CreateVipUser(UserName);

            return Ok("user vip created Successfully");
        }
    }
}
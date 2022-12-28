using Microsoft.AspNetCore.Mvc;
using Api.Entities;
using Api.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace App.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        //janek@gmail.com
        //Janek141#21
        [HttpGet("GetUser")]
        public async Task GetUser()
        {

        }
        [HttpPost("AddProfile")]
        public async Task<IActionResult> AddUserProfile(UserProfileDto model)
        {
            
            return Ok(await _mediator.Send(model));
        }

    
    }
}


using Microsoft.AspNetCore.Mvc;
using Api.Entities;
using Api.DTOs;
using Api.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Api.Repositories;
using Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;

namespace App.Controllers
{
    [Authorize]
    public class UserController : Controller
    {


        private readonly IUserRepo _userRepo;
        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        //adameczek@gmail.com
        //adeeekhaha
        //Janek141214#21


        [HttpGet("GetUserByName")]
        public async Task<IActionResult> GetUser(String name)
        {
           var user =  await _userRepo.GetUserByName(name);

            if (user!=null) return Ok(user);

            return NotFound();
        }


        [HttpPost("AddProfile")]
        public async Task<IActionResult> AddUserProfile(UserProfileDto model)
        {
           var userProfile =  await _userRepo.AddUserProfile(model);

            return Ok(userProfile);

          
        }

    
    }
}


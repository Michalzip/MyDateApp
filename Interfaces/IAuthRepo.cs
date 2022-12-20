using System;
using App.DTOs;
using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Interfaces
{

 
    public interface IAuthRepo
    {

        Task<ActionResult<UserDetailDto>> Register(RegisterDto model);
        Task<ActionResult<UserDto>> Login(LoginDto model);
      
    }

}


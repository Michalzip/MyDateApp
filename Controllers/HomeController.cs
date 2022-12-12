using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using Microsoft.AspNetCore.Identity;
using App.Db;

using App.AuthRepository;
using System;
using App.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers;

public class HomeController : Controller
{

    private readonly IAuthRepo _authRepo;

    public HomeController(IAuthRepo authRepo)
    {
        
        _authRepo = authRepo;

    }


    [HttpPost("Register")]
    public async Task Register(UserRegisterModel model)
    {

        await _authRepo.SaveUser(model);
        
    }

    [HttpPost("Login")]
    public async Task Login(UserLoginModel model)
    {

      await  _authRepo.SignInUser(model);
       

    }

    [HttpGet("GetUser")]
    [Authorize]
    public async Task GetUser(){

        Ok("Hello I am User");
    }

}


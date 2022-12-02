using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using Microsoft.AspNetCore.Identity;
using App.Db;
using App.Services;
using App.AuthRepository;
using System;
using App.Interfaces;
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
        if (ModelState.IsValid)
        {
            await _authRepo.Register(model);
            Ok();

        }






    }
}


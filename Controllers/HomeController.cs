
using Microsoft.AspNetCore.Mvc;
using App.DTOs;
using App.Interfaces;
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
    public async Task Register(RegisterDto model)
    {

        await _authRepo.SaveUser(model);

    }

    [HttpPost("Login")]
    public async Task Login(LoginDto model)
    {

        await _authRepo.SignInUser(model);


    }

    [HttpGet("GetUser")]
    [Authorize]
    public async Task GetUser()
    {


    }

    public async Task<IActionResult> Index()
    {

        return View();

    }


    public async Task<IActionResult> Privacy()
    {

        return View();

    }

}


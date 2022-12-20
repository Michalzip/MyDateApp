using System;
using App.Db;
using App.Models;
using Microsoft.AspNetCore.Identity;
using App.Controllers;
using App.DTOs;
using App.Interfaces;
using App.Services;
using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
namespace App.AuthRepository
{
    public class AuthRepo : IAuthRepo
    {


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public readonly TokenService _token;
        private readonly IMapper _mapper;

        public AuthRepo(IMapper
        mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TokenService token)
        {


            _userManager = userManager;
            _signInManager = signInManager;
            _token = token;
            _mapper = mapper;

        }


        public async Task<ActionResult<UserDetailDto>> Register(RegisterDto model)
        {

            
            var user = _mapper.Map<ApplicationUser>(model);

            await _userManager.CreateAsync(user, model.Password);

            return new UserDetailDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.PasswordHash,
                CreatedAt = user.CreatedAt
            };
        }



        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);

            await _signInManager.PasswordSignInAsync(user.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);

            return new UserDto
            {
                UserName = user.UserName,
                Token = await _token.CreateToken(user)
            };
        }

    }


}






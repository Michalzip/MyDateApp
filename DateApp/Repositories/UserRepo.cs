using System;
using Api.DTOs;
using Api.Entities;
using Api.Repositories.Interfaces;
using App.Db;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Repositories
{
    public class UserRepo: IUserRepo
    {

        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        public UserRepo(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<UserProfile> GetUserByName(string userName)
        {

            var user = _context.UserProfiles.FirstOrDefault(u => u.UserName == userName);

            return user;

        }


        public async Task<UserProfile> AddUserProfile(UserProfileDto model)
        {

            var userProfile = await _mediator.Send(model);

            return userProfile;

        }

    }
}


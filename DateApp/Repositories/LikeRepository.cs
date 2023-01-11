using System;
using App.Db;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using DateApp.DTOs;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly AppDbContext _context;

        public LikeRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<bool> CheckExistsLike(UserLike like)
        {

            return await _context.UserLikes
             .Where(u => u.ByUser.UserName == like.ByUser.UserName)
             .AnyAsync(u => u.ToUser.UserName == like.ToUser.UserName);


        }

        public async Task<List<UserLike>> GetLikeUsers(string sourceUserName)
        {

            return await _context.UserLikes.Where(u => u.ToUser.UserName == sourceUserName).ToListAsync();

        }

        public async Task<List<UserLike>> GetLikedUsers(string sourceUserName)
        {
            return await _context.UserLikes.Where(u => u.ByUser.UserName == sourceUserName).ToListAsync();

        }

        public void AddLike(UserLike like)
        {

            _context.Add(like);
        }




    }
}


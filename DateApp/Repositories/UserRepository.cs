using Api.DTOs;
using Api.Entities;
using App.Db;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<UserProfile> GetUser(string username)
        {

            return await _context.UserProfiles.Where(u => u.UserName == username).FirstOrDefaultAsync();

        }

        public void AddUserProfile(UserProfile user)
        {


            _context.UserProfiles.Add(user);


        }

    }
}


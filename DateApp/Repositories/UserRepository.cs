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

            var result = _context.UserProfiles.Where(u => u.UserName == username);
            //.ProjectTo<UserGetProfileDto>(_mapper.ConfigurationProvider);

            return await result.FirstOrDefaultAsync();
        }

        //public async Task<UserGetProfileDto> GetUserByIdAsync(int id)
        //{

        //    var result = _context.UserProfiles.FindAsync(id);

        //    _mapper.ProjectTo<UserGetProfileDto>(result).FirstOrDefault();
        //        //ProjectTo<UserGetProfileDto>(_mapper.ConfigurationProvider);

        //    //.FindAsync(id)
        //    //
        //    return  await  result.Find(id);


        //}


  


        public void AddUserProfile(UserProfile user)
        {


            _context.UserProfiles.Add(user);


        }

    }
}


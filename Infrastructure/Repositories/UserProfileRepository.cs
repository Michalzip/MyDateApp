
using Api.Entities;
using App.Db;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class UserProfileRepository : RepositoryBase<UserProfile>, IUserProfileRepository
    {

        public UserProfileRepository(AppDbContext context)
        : base(context)
        {
        }

        public async Task<UserProfile> GetUserProfileByName(string name)
        {
            return await _dbContext.UserProfiles.Where(u => u.UserName == name).FirstOrDefaultAsync();
        }


    }
}
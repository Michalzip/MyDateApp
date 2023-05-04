
using Domain.Entities;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class UserProfileRepository : RepositoryBase<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(CoreContext context)
        : base(context)
        {
        }

        public async Task<UserProfile> getUserProfileByName(string name)
        {
            return await _dbContext.UserProfiles.Where(u => u.UserName == name).FirstOrDefaultAsync();
        }
        public bool ExistsUserProfile(string id)
        {
            return _dbContext.UserProfiles.Any(up => up.Id == id);
        }
    }
}
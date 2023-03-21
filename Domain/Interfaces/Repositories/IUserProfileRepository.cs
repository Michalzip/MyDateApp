using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        public Task<UserProfile> getUserProfileByName(string name);
    }
}
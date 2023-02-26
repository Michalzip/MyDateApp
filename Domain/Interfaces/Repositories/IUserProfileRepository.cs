using Api.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        public Task<UserProfile> GetUserProfileByName(string name);
    }
}
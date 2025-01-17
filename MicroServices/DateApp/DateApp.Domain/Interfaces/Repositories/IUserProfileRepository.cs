
namespace Domain.Interfaces.Repositories
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        public Task<UserProfile> getUserProfileByName(string name);
        public bool ExistsUserProfile(string id);
    }
}
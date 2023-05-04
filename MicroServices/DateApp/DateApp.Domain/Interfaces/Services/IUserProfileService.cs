using Domain.Entities;


namespace DateApp.Domain.Interfaces.Services
{
    public interface IUserProfileService
    {
        public Task CreateUserProfile(string firstName, string lastName, string photoUrl);

        public Task<UserProfile> GetUserProfile(string name);
    }
}
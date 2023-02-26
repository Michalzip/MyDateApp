using Api.Entities;
using Server.Models;

namespace Domain.Interfaces.Services
{
    public interface IUserProfileService
    {
        public Task<int> CreateUserProfile(string firstName, string lastName, string photoUrl);

        public Task<UserProfile> GetUserProfile(string name);
    }
}
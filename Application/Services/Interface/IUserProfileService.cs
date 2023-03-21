using Domain.Entities;
using Server.Models;

namespace Application.Interfaces.Services
{
    public interface IUserProfileService
    {
        public Task<int> CreateUserProfile(string firstName, string lastName, string photoUrl);

        public Task<UserProfileDto> GetUserProfile(string name);
    }
}
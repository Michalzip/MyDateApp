using Api.Entities;
using Server.Models;

namespace Domain.Interfaces.Services
{
    public interface ITokenService
    {
        public Task<string> CreateToken(ApplicationUser user);
    }
}
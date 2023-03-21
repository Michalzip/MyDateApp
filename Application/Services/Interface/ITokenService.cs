using Domain.Entities;
using Server.Models;

namespace Application.Interfaces.Services
{
    public interface ITokenService
    {
        public Task<string> CreateToken(ApplicationUser user);
    }
}
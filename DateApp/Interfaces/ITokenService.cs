
using App.Models;
using Microsoft.AspNetCore.Identity;

namespace App.Interfaces
{


    public interface CreateToken
    {
        public Task<string> CreateToken(IdentityUser user);
    }

    public interface ITokenService : CreateToken
    {
    }
}


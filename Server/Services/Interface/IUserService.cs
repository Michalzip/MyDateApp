using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services.Interface
{
    public interface IUserService
    {
        public Task<IdentityResult> CreateVipIdentityUser(string username);
        public Task<IdentityResult> CreateIdentityUser(string email, string username, string password);
        public Task<SignInResult> AuthenticateIdentityUser(string email, string password);
        public Task<ApplicationUser> GetIdentityUser(string username);
    }
}
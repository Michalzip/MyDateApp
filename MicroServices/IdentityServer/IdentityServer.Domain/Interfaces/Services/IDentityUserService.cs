namespace IdentityServer.Domain.Interfaces.Services
{
    public interface IDentityUserService
    {
        public Task<ApplicationUser> GetIdentityUserByName(string name);
        public Task<IdentityResult> CreateVipUser(string name);
    }
}
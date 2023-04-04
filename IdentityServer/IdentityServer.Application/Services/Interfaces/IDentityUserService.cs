namespace IdentityServer.Application.Services.Interfaces
{
    public interface IDentityUserService
    {
        public Task<ApplicationUser> GetIdentityUserByName(string name);
        public Task<IdentityResult> CreateVipUser(string name);
        public Task<bool> GetVipStatus(string name);
    }
}
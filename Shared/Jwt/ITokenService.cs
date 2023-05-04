using Shared.Models;
namespace Shared.Jwt
{
    public interface ITokenService
    {
        public Task<string> CreateToken(string id, string name);
        public ClaimUser GetTokenData(string token);

        public void RemoveToken();
    }
}
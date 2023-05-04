
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Shared.Models;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Caching.Memory;

namespace Shared.Jwt
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IMemoryCache _memoryCache;
        private readonly string _cacheKey;

        private readonly JwtSecurityTokenHandler _tokenHandler;

        public TokenService(IMemoryCache memoryCache)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ETB4GNHYY2ETB4GNHYY2"));
            _memoryCache = memoryCache;
            _cacheKey = "jwtToken";
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task<string> CreateToken(string id, string name)
        {
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(ClaimTypes.Name,name)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = credentials
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);

            var jwtToken = _tokenHandler.WriteToken(token);

            _memoryCache.Set(_cacheKey, jwtToken);

            Console.WriteLine("token invoked" + jwtToken);

            return jwtToken;
        }

        public ClaimUser GetTokenData(string token)
        {
            JwtSecurityToken jwtToken = _tokenHandler.ReadJwtToken(token);

            Console.WriteLine(jwtToken);

            var userId = jwtToken.Claims?.FirstOrDefault(c => c.Type == "nameid").Value;

            var userName = jwtToken.Claims?.FirstOrDefault(c => c.Type == "unique_name").Value;

            return new ClaimUser { Id = userId, UserName = userName };
        }

        public void RemoveToken()
        {
            _memoryCache.Remove(_cacheKey);
        }
    }
}


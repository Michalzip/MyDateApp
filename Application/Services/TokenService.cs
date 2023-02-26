
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using Domain.Interfaces.Services;
namespace App.Services
{
    public class TokenService : ITokenService
    {

        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;


        public TokenService(IConfiguration config, UserManager<ApplicationUser> userManager)
        {
            _config = config;

            _userManager = userManager;

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

        }

        public async Task<string> CreateToken(ApplicationUser user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),

            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials

            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);


        }

    }

}




using Server.Models;

namespace Api.Repository
{
    public class AuthRepository : IAuthRepository
    {

        private readonly IIdentityUserRepo _identityUserRepo;

        private readonly ITokenService _tokenService;

        public AuthRepository(IIdentityUserRepo identityUserRepo, ITokenService tokenService)
        {
            _identityUserRepo = identityUserRepo;
            _tokenService = tokenService;
        }

        public async Task<IdentityResult> RegisterUser(RegisterDto model)
        {


            var userIdentity = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.UserName,
                PasswordHash = model.Password,
            };

            return await _identityUserRepo.InsertIdentityUser(userIdentity);

        }


        public async Task<SignInResult> LoginUser(LoginDto model)
        {
            var userIdentity = new ApplicationUser
            {

                Email = model.Email,
                PasswordHash = model.Password

            };

            var result = await _identityUserRepo.AuthenticateIdentityUser(userIdentity);

            if (result.Succeeded) await _tokenService.CreateToken(userIdentity);


            return result;

        }
    }

}









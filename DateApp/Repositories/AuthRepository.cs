

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

        public async Task<IdentityResult> RegisterUser(ApplicationUser user)
        {

            return await _identityUserRepo.InsertIdentityUser(user);

        }


        public async Task<SignInResult> LoginUser(ApplicationUser user)
        {

            var result = await _identityUserRepo.AuthenticateIdentityUser(user);

            if (result.Succeeded) await _tokenService.CreateToken(user);


            return result;

        }
    }

}









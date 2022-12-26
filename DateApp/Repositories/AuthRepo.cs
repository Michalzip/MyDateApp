using Microsoft.AspNetCore.Identity;



namespace App.AuthRepository
{
    public class AuthRepo : IAuthRepo
    {
        public readonly TokenService _token;
        private readonly IdentityService _identityService;


        public AuthRepo(IdentityService identityService, TokenService token)
        {

            _token = token;
            _identityService = identityService;
        }


        public async Task<IdentityUser> Register(RegisterDto model)
        {

            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.UserName,
                PasswordHash = model.Password,
            };


             await _identityService.AddIdentityUser(user);

            return user;


        }



        public async Task<IdentityUser> Login(LoginDto model)
        {

            var user = new IdentityUser { Email = model.Email, PasswordHash = model.Password };

           
            await _identityService.AuthenticateIdentityUser(user);

            return user;

    
           
        }

    }


}






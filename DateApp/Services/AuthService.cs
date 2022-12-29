using System;
using App.AuthRepository;
using Api.Services.Interfaces;
using Server.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using IdentityServer4;
using Server.Repository.interfaces;

namespace Api.Services
{
	public class AuthService:IAuthService
	{
      
		private readonly IIdentityUserRepo _identityUserRepo;
        public readonly  AuthRepo _authRepo;
		private readonly TokenService _tokenService;

        public AuthService(AuthRepo authRepo, IIdentityUserRepo identityUserRepo,TokenService tokenService)
		{
			_authRepo = authRepo;
            _identityUserRepo = identityUserRepo;
            _tokenService = tokenService;

        }


		public async Task<IdentityResult> RegisterUser(RegisterDto model)
		{
			var user = _authRepo.SetUserFromRegister(model);

			var result = await _identityUserRepo.InsertIdentityUser(user);

			return result;

        }


		public async Task<SignInResult> LoginUser(LoginDto model)
		{
            var user = _authRepo.SetUserFromLogin(model);

			var result = await _identityUserRepo.AuthenticateIdentityUser(user);

			if (result.Succeeded) await _tokenService.CreateToken(user);

			return result;
			
        }


      

    }
}


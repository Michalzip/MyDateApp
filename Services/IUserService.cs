using System;
using App.Models;

namespace App.Services
{
	public interface IUserService
	{

        public ApplicationUser SetUser(UserRegisterModel model);

    }
}


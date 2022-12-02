using System;
using App.Models;
using Microsoft.AspNetCore.Identity;

namespace App.Interfaces
{
	public interface IUserService
	{

        public ApplicationUser CreateUser(IUserRegister model);
        public  Task SaveUser(ApplicationUser user);
        
        

    }
}


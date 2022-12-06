using System;
using App.Models;

namespace App.Interfaces
{

        public interface SaveUser
    {
        Task SaveUser(UserRegisterModel model);
    }

    public interface SignInUser
    {
        Task SignInUser(UserLoginModel model);
    }

    public interface IAuthRepo: SaveUser, SignInUser
    {
           
      }
    
}


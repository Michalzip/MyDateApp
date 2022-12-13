using System;
using App.Models;

namespace App.Interfaces
{

        public interface SaveUser
    {
        Task SaveUser(UserSignUp model);
    }

    public interface SignInUser
    {
        Task SignInUser(UserSignIn model);
    }

    public interface IAuthRepo: SaveUser, SignInUser
    {
           
      }
    
}


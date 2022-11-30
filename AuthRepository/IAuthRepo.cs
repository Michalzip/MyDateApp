using System;
using App.Models;

namespace App.AuthRepository
{
   
        public interface IAuthRepo
        {
            Task Register(UserRegisterModel model);
       
        }
    
}


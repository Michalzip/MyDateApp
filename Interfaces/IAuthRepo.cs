using System;
using App.Models;

namespace App.Interfaces
{
   
        public interface IAuthRepo
        {
            Task Register(IUserRegister model);
       
        }
    
}


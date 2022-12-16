using System;
using App.DTOs;
using App.Models;

namespace App.Interfaces
{

    public interface SaveUser
    {
        Task SaveUser(RegisterDto model);
    }

    public interface SignInUser
    {
        Task SignInUser(LoginDto model);
    }

    public interface IAuthRepo : SaveUser, SignInUser
    {

    }

}


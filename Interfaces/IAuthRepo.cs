using System;
using App.Models;

namespace App.Interfaces
{

    public interface SaveUser
    {
        Task SaveUser(UserDetailDto model);
    }

    public interface SignInUser
    {
        Task SignInUser(UserAuthModel model);
    }

    public interface IAuthRepo : SaveUser, SignInUser
    {

    }

}


using System;
using DateApp.DTOs;

namespace Api.Repositories.Interfaces
{
    public interface ILikeRepository
    {

        void AddLike(UserLike like);
        Task<List<UserLike>> GetLikedUsers(string sourceUserName);
        Task<List<UserLike>> GetLikeUsers(string sourceUserName);
        Task<bool> CheckExistsLike(UserLike like);

    }
}


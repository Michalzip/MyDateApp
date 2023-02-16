using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateApp.Services.Interfaces
{
    public interface ILikeService
    {
        Task<LikeDto> CreateLikeFromQuery(string byUser, string toUser);
        Task<List<LikeDto>> GetLikesProfiles(string byUser);
        Task<List<LikeDto>> GetLikedProfiles(string byUser);

    }
}
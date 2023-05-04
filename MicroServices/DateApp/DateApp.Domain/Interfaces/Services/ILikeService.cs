using Domain.Entities;


namespace DateApp.Domain.Interfaces.Services
{
    public interface ILikeService
    {
        Task CreateLikeFromQuery(string byUser, string toUser);
        Task<List<UserLike>> GetLikesProfiles(string byUser);
        Task<List<UserLike>> GetLikedProfiles(string byUser);

    }
}
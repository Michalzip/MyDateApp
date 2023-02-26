using Api.Entities;


namespace Domain.Interfaces.Services
{
    public interface ILikeService
    {
        Task<int> CreateLikeFromQuery(string byUser, string toUser);
        Task<List<UserLike>> GetLikesProfiles(string byUser);
        Task<List<UserLike>> GetLikedProfiles(string byUser);

    }
}
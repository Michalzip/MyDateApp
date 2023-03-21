using Domain.Entities;


namespace Application.Interfaces.Services
{
    public interface ILikeService
    {
        Task<int> CreateLikeFromQuery(string byUser, string toUser);
        Task<List<LikeDto>> GetLikesProfiles(string byUser);
        Task<List<LikeDto>> GetLikedProfiles(string byUser);

    }
}
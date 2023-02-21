namespace DateApp.Services.Interfaces
{
    public interface ILikeService
    {
        Task<int> CreateLikeFromQuery(string byUser, string toUser);
        Task<List<UserLike>> GetLikesProfiles(string byUser);
        Task<List<UserLike>> GetLikedProfiles(string byUser);

    }
}
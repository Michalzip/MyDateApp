namespace Domain.Interfaces.Repositories
{
    public interface ILikeRepository : IRepository<UserLike>
    {
        public Task<List<UserLike>> getLikeUsers(string name);
        public Task<List<UserLike>> getLikedUsers(string name);
        public Task<bool> existsLike(string sourceName, string receiverName);
    }
}
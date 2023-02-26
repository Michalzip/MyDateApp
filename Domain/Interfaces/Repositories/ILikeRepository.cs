using Api.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ILikeRepository : IRepository<UserLike>
    {
        public Task<List<UserLike>> GetLikeUsers(string name);
        public Task<List<UserLike>> GetLikedUsers(string name);
        public Task<bool> ExistsLike(string sourceName, string receiverName);
    }
}
using Api.Entities;
using App.Db;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class LikeRepository : RepositoryBase<UserLike>, ILikeRepository
    {
        public LikeRepository(AppDbContext context)
              : base(context)
        {
        }

        public async Task<List<UserLike>> GetLikeUsers(string name)
        {
            return await _dbContext.UserLikes.Where(u => u.ToUser.UserName == name).ToListAsync();
        }

        public async Task<List<UserLike>> GetLikedUsers(string name)
        {
            return await _dbContext.UserLikes.Where(u => u.ByUser.UserName == name).ToListAsync();
        }

        public async Task<bool> ExistsLike(string sourceName, string receiverName)
        {
            return await _dbContext.UserLikes
              .Where(u => u.ByUser.UserName == sourceName)
              .AnyAsync(u => u.ToUser.UserName == receiverName);
        }


    }
}
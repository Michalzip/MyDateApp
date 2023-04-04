using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Repositories;
using Infrastructure.Db;


namespace Infrastructure.Repositories
{
    public class LikeRepository : RepositoryBase<UserLike>, ILikeRepository
    {


        public LikeRepository(CoreContext context)
              : base(context)
        {

        }



        public async Task<List<UserLike>> getLikeUsers(string name)
        {
            return await _dbContext.UserLikes.Where(u => u.ToUser.UserName == name).ToListAsync();


        }

        public async Task<List<UserLike>> getLikedUsers(string name)
        {
            return await _dbContext.UserLikes.Where(u => u.ByUser.UserName == name).ToListAsync();


        }

        public async Task<bool> existsLike(string sourceName, string receiverName)
        {
            return await _dbContext.UserLikes
              .Where(u => u.ByUser.UserName == sourceName)
              .AnyAsync(u => u.ToUser.UserName == receiverName);
        }


    }
}
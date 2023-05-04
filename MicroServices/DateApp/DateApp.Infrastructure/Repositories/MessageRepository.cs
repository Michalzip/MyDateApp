using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Repositories;
using Infrastructure.Db;
namespace Infrastructure.Repositories
{
    public class MessageRepository : RepositoryBase<UserMessage>, IMessageRepository
    {
        public MessageRepository(CoreContext context)
               : base(context)
        {
        }
        public async Task<List<UserMessage>> getAllMessages(string sourceName, string receiverName)
        {
            return await _dbContext.UserMessages
              .Include(x => x.ByUser)
              .Include(x => x.ToUser)
              .Where(u => u.ByUser.UserName == sourceName && u.ToUser.UserName == receiverName
               || u.ByUser.UserName == receiverName && u.ToUser.UserName == sourceName
              )
              .ToListAsync();
        }

        public async Task<List<UserMessage>> getMessagesByTime(string sourceName, string receiverName, int hourFrom, int hourTo, int day)
        {
            return await _dbContext.UserMessages
                 .Include(x => x.ByUser)
                 .Include(x => x.ToUser)
                 .Where(u => u.CreatedAt.Hour >= hourFrom && u.CreatedAt.Hour <= hourTo && u.CreatedAt.Day == day
                 && u.ByUser.UserName == sourceName && u.ToUser.UserName == receiverName
                 || u.ByUser.UserName == receiverName && u.ToUser.UserName == sourceName
                 && u.CreatedAt.Hour >= hourFrom && u.CreatedAt.Hour <= hourTo && u.CreatedAt.Day == day
                 ).ToListAsync();
        }

        public async Task<UserMessage> getMessageById(int id)
        {
            return await _dbContext.UserMessages
                .Include(u => u.ByUser)
                .Include(u => u.ToUser)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
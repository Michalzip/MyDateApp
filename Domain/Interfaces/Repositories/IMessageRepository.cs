using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IMessageRepository : IRepository<UserMessage>
    {
        public Task<List<UserMessage>> getAllMessages(string sourceName, string receiverName);
        public Task<List<UserMessage>> getMessagesByTime(string sourceName, string receiverName, int hourFrom, int hourTo, int day);
        public Task<UserMessage> getMessageById(int id);

    }
}
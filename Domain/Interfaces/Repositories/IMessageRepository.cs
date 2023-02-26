using Api.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IMessageRepository : IRepository<UserMessage>
    {
        public Task<List<UserMessage>> GetAllMessages(string sourceName, string receiverName);
        public Task<List<UserMessage>> GetMessagesByTime(string sourceName, string receiverName, int hourFrom, int hourTo, int day);

        public Task<UserMessage> GetMessageById(int id);

    }
}
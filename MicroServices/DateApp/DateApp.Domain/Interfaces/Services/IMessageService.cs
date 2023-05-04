using Domain.Entities;

namespace DateApp.Domain.Interfaces.Services
{
    public interface IMessageService
    {
        public Task CreateMessageFromQuery(string byUser, string toUser, string message);
        public Task<List<UserMessage>> GetAllMessages(string byUserName, string toUserName);
        public Task<List<UserMessage>> GetMessageByTime(string byUserName, string toUserName, int hourTo, int hourFrom, int day);
        public Task DeleteMessageById(int id);

    }
}
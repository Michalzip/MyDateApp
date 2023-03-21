using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IMessageService
    {
        public Task<int> CreateMessageFromQuery(string byUser, string toUser, string message);
        public Task<List<MessageDto>> GetAllMessages(string byUserName, string toUserName);
        public Task<List<MessageDto>> GetMessageByTime(string byUserName, string toUserName, int hourTo, int hourFrom, int day);
        public Task<int> DeleteMessageById(int id);

    }
}
namespace DateApp.Services.Interfaces
{
    public interface IMessageService
    {
        public Task<int> CreateMessageFromQuery(string byUser, string toUser, string message);
        public Task<List<UserMessage>> GetAllMessages(string byUserName, string toUserName);
        public Task<List<UserMessage>> GetMessageByTime(string byUserName, string toUserName, int hourTo, int hourFrom, int day);
        public Task<int> DeleteMessageById(int id);
    }
}
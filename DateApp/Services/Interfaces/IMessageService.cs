using System;
using System.Collections.Generic;
using System.Linq;
using DateApp.Helpers;
using System.Threading.Tasks;

namespace DateApp.Services.Interfaces
{
    public interface IMessageService
    {
        public Task<MessageDto> CreateMessageFromQuery(string byUser, string toUser, string message);
        public Task<PagedList<MessageDto>> GetAllMessages(string byUserName, string toUserName, PaginationParams paginationParams);
        public Task<List<MessageDto>> GetMessageByTimeQuery(string byUserName, string toUserName, int hourTo, int hourFrom, int day);
        public Task<bool> DeleteMessageById(int id);
    }
}
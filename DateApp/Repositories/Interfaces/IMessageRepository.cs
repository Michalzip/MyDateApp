using System;
using Api.DTOs;
using Api.Entities;

namespace Api.Repositories.Interfaces
{
	public interface IMessageRepository
	{
        Task<UserMessage> CheckAuthorMessage(string currentUserName, int messageId);
        void AddMessage(UserMessage message);
        void DeleteMessage(UserMessage message);
        Task<UserMessage> GetMessage(int id);
        Task<List<UserMessage>> GetMessages(string currentUserName, string receiverUserName);
        Task<List<UserMessage>> GetMessagesByTime(MessageDto message,int hourFrom , int hourTo,int day);

    }
}


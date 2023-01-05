using System;
using Api.DTOs;
using Api.Entities;

namespace Api.Repositories.Interfaces
{
	public interface IMessageRepository
	{
        void AddMessage(UserMessage message);
        Task<List<UserMessage>> GetConversation(string currentUserName, string receiverUserName);

    }
}


using System;
using Api.Repositories.Interfaces;
using Api.DTOs;
using Api.Entities;
using App.Db;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
	public class MessageRepository:IMessageRepository
	{
        private readonly AppDbContext _context;

        public MessageRepository(AppDbContext context)
		{
            _context = context;

        }



        public async Task<List<UserMessage>> GetConversation(string currentUserName, string receiverUserName)
        {
            var result = await _context.UserMessages.Include(x=>x.ByUserMessage).Include(x=>x.ToUserMessage).Where(u=>u.ByUserMessage.UserName == currentUserName && u.ToUserMessage.UserName == receiverUserName
            || u.ByUserMessage.UserName == receiverUserName && u.ToUserMessage.UserName == currentUserName
            ).ToListAsync();

            return result;



        }



        //public async Task
        public void AddMessage(UserMessage message)
        {

            _context.Add(message);
        }


    }
}


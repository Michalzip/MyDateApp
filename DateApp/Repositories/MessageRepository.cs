using System;
using Api.Repositories.Interfaces;
using Api.DTOs;
using Api.Entities;
using App.Db;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;

        public MessageRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<UserMessage> CheckAuthorMessage(string currentUserName, int messageId)
        {

            return await _context.UserMessages.Where(u => u.ByUser.UserName == currentUserName && u.Id == messageId).FirstOrDefaultAsync();

        }


        public async Task<UserMessage> GetMessage(int id)
        {
            return await _context.UserMessages
                .Include(u => u.ByUser)
                .Include(u => u.ToUser)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserMessage>> GetMessages(string currentUserName, string receiverUserName)
        {

            return await _context.UserMessages
               .Include(x => x.ByUser)
               .Include(x => x.ToUser)
               .Where(u => u.ByUser.UserName == currentUserName && u.ToUser.UserName == receiverUserName
                || u.ByUser.UserName == receiverUserName && u.ToUser.UserName == currentUserName
               )
               .ToListAsync();
        }

        public async Task<List<UserMessage>> GetMessagesByTime(MessageDto message, int hourFrom, int hourTo, int day)
        {

            return await _context.UserMessages
                 .Include(x => x.ByUser)
                 .Include(x => x.ToUser)
                 .Where(u => u.CreatedAt.Hour >= hourFrom && u.CreatedAt.Hour <= hourTo && u.CreatedAt.Day == day
                 && u.ByUser.UserName == message.Sender && u.ToUser.UserName == message.Receiver
                 || u.ByUser.UserName == message.Receiver && u.ToUser.UserName == message.Sender
                 && u.CreatedAt.Hour >= hourFrom && u.CreatedAt.Hour <= hourTo && u.CreatedAt.Day == day
                 )

                 .ToListAsync();

        }

        public void AddMessage(UserMessage message)
        {

            _context.Add(message);
        }

        public void DeleteMessage(UserMessage message)
        {
            _context.UserMessages.Remove(message);
        }

    }
}


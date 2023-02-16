using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateApp.Services.Interfaces;
using DateApp.Functions.LikeFunctions.Queries;
using DateApp.Functions.LikeFunctions.Commands;
using DateApp.Functions.MessageFunctions.Commands;
using DateApp.Functions.MessageFunctions.Queries;
using DateApp.Helpers;

namespace DateApp.Services
{


    public class MessageService : IMessageService
    {
        private readonly IMediator _mediator;

        public MessageService(IMediator mediator)
        {
            _mediator = mediator;
        }



        public async Task<MessageDto> CreateMessageFromQuery(string byUserName, string toUserName, string message)
        {

            var user1 = new GetUserByNameQuery
            {
                userName = byUserName
            };


            var byUserProfile = await _mediator.Send(user1);


            var user2 = new GetUserByNameQuery
            {
                userName = toUserName
            };

            var toUserProfile = await _mediator.Send(user2);


            var userMessage = new CreateMessageCommand
            {
                ByUser = byUserProfile,
                ToUser = toUserProfile,
                Message = message

            };

            return await _mediator.Send(userMessage);


        }


        public async Task<PagedList<MessageDto>> GetAllMessages(string byUserName, string toUserName, PaginationParams paginationParams)
        {

            var messagesQuery = new GetAllMessagesQuery
            {
                ByUserName = byUserName,
                ToUserName = toUserName,
                PaginationParams = paginationParams

            };

            var messages = await _mediator.Send(messagesQuery);


            return messages;

        }


        public async Task<List<MessageDto>> GetMessageByTimeQuery(string byUserName, string toUserName, int hourTo, int hourFrom, int day)
        {

            var messagesQuery = new GetMessageByTimeQuery
            {
                ByUserName = byUserName,
                ToUserName = toUserName,
                HourTo = hourTo,
                HourFrom = hourFrom,
                Day = day

            };

            var messages = await _mediator.Send(messagesQuery);

            return messages;

        }


        public async Task<bool> DeleteMessageById(int id)
        {
            var idMessage = new GetMessageByIdQuery
            {
                Id = id
            };


            var message = await _mediator.Send(idMessage);


            var idMessageToDelete = new DeleteMessageByIdCommand
            {

                Id = message.Id
            };

            var deleteCompleteResult = await _mediator.Send(idMessageToDelete);

            return deleteCompleteResult;


        }

    }
}
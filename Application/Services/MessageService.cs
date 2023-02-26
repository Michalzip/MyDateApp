using DateApp.Functions.MessageFunctions.Commands;
using DateApp.Functions.MessageFunctions.Queries;
using Domain.Interfaces.Services;

namespace DateApp.Services
{


    public class MessageService : IMessageService
    {
        private readonly IMediator _mediator;

        public MessageService(IMediator mediator)
        {
            _mediator = mediator;
        }



        public async Task<int> CreateMessageFromQuery(string byUserName, string toUserName, string message)
        {

            var user1 = new GetUserByNameQuery
            {
                UserName = byUserName
            };


            var byUserProfile = await _mediator.Send(user1);


            var user2 = new GetUserByNameQuery
            {
                UserName = toUserName
            };


            var toUserProfile = await _mediator.Send(user2);

            if (toUserProfile == null) return 0;

            var userMessage = new CreateMessageCommand
            {
                ByUser = byUserProfile,
                ToUser = toUserProfile,
                Message = message

            };

            return await _mediator.Send(userMessage);


        }


        public async Task<List<UserMessage>> GetAllMessages(string byUserName, string toUserName)
        {

            var messagesQuery = new GetAllMessagesQuery
            {
                ByUserName = byUserName,
                ToUserName = toUserName,


            };

            return await _mediator.Send(messagesQuery);




        }


        public async Task<List<UserMessage>> GetMessageByTime(string byUserName, string toUserName, int hourTo, int hourFrom, int day)
        {

            var messagesQuery = new GetMessageByTimeQuery
            {
                ByUserName = byUserName,
                ToUserName = toUserName,
                HourTo = hourTo,
                HourFrom = hourFrom,
                Day = day

            };

            return await _mediator.Send(messagesQuery);

        }


        public async Task<int> DeleteMessageById(int id)
        {
            var idMessage = new GetMessageByIdQuery
            {
                Id = id
            };


            var message = await _mediator.Send(idMessage);

            if (message == null) return 0;


            var MessageToDelete = new DeleteMessageByIdCommand
            {

                UserMessage = message
            };

            return await _mediator.Send(MessageToDelete);




        }


    }
}
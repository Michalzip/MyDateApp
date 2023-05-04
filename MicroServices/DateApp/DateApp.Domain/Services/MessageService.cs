
using DateApp.Domain.Functions.MessageFunctions.Commands;
using DateApp.Domain.Functions.MessageFunctions.Queries;

namespace DateApp.Domain.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMediator _mediator;
        public MessageService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task CreateMessageFromQuery(string byUserName, string toUserName, string message)
        {
            var byUserProfile = await _mediator.Send(new GetUserByNameQuery { UserName = byUserName });
            var toUserProfile = await _mediator.Send(new GetUserByNameQuery { UserName = toUserName });

            if (toUserProfile == null) throw new NotFoundException("User does not exist");

            var userMessage = new UserMessage
            {
                ByUser = byUserProfile,
                ToUser = toUserProfile,
                Message = message
            };

            var result = await _mediator.Send(new CreateMessageCommand { Message = userMessage });

            if (result == 0) throw new FailedOperationException("failed to create message");
        }

        public async Task<List<UserMessage>> GetAllMessages(string byUserName, string toUserName)
        {
            return await _mediator.Send(new GetAllMessagesQuery { ByUserName = byUserName, ToUserName = toUserName, });
        }

        public async Task<List<UserMessage>> GetMessageByTime(string byUserName, string toUserName, int hourTo, int hourFrom, int day)
        {
            return await _mediator.Send(new GetMessageByTimeQuery { ByUserName = byUserName, ToUserName = toUserName, HourTo = hourTo, HourFrom = hourFrom, Day = day });
        }

        public async Task DeleteMessageById(int id)
        {
            var message = await _mediator.Send(new GetMessageByIdQuery { Id = id });

            if (message == null) throw new NotFoundException("no message with this id found");

            var result = await _mediator.Send(new DeleteMessageByIdCommand { Message = message });

            if (result == 0) throw new FailedOperationException("message could not be deleted ");
        }
    }
}
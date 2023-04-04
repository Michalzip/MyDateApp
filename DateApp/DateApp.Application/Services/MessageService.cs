using Application.DTOs;
using Application.Functions.MessageFunctions.Commands;
using Application.Functions.MessageFunctions.Queries;
using Application.Interfaces.Services;


namespace Application.Services
{


    public class MessageService : IMessageService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MessageService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        public async Task<int> CreateMessageFromQuery(string byUserName, string toUserName, string message)
        {

            var byUserProfile = await _mediator.Send(new GetUserByNameQuery { UserName = byUserName });

            var toUserProfile = await _mediator.Send(new GetUserByNameQuery { UserName = toUserName });

            if (toUserProfile == null) return 0;

            var userMessage = new UserMessage
            {
                ByUser = byUserProfile,
                ToUser = toUserProfile,
                Message = message
            };

            return await _mediator.Send(new CreateMessageCommand { Message = userMessage });


        }


        public async Task<List<MessageDto>> GetAllMessages(string byUserName, string toUserName)
        {

            var messages = await _mediator.Send(new GetAllMessagesQuery { ByUserName = byUserName, ToUserName = toUserName, });

            return _mapper.Map<List<UserMessage>, List<MessageDto>>(messages);
        }


        public async Task<List<MessageDto>> GetMessageByTime(string byUserName, string toUserName, int hourTo, int hourFrom, int day)
        {

            var messages = await _mediator.Send(new GetMessageByTimeQuery { ByUserName = byUserName, ToUserName = toUserName, HourTo = hourTo, HourFrom = hourFrom, Day = day });

            return _mapper.Map<List<UserMessage>, List<MessageDto>>(messages);


        }


        public async Task<int> DeleteMessageById(int id)
        {


            return await _mediator.Send(new DeleteMessageByIdCommand { Id = id });

        }


    }
}
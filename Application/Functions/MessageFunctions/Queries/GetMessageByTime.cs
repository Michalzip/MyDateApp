using Domain.Interfaces.Repositories;

namespace DateApp.Functions.MessageFunctions.Queries
{
    public class GetMessageByTimeQuery : IRequest<List<UserMessage>>
    {
        public string? ByUserName { get; set; }
        public string? ToUserName { get; set; }
        public int HourFrom { get; set; }
        public int HourTo { get; set; }
        public int Day { get; set; }

        public class GetMessageByTime : IRequestHandler<GetMessageByTimeQuery, List<UserMessage>>
        {

            private readonly IMessageRepository _messageRepository;

            public GetMessageByTime(IMessageRepository messageRepository)
            {
                _messageRepository = messageRepository;

            }

            async Task<List<UserMessage>> IRequestHandler<GetMessageByTimeQuery, List<UserMessage>>.Handle(GetMessageByTimeQuery request, CancellationToken cancellationToken)
            {
                return await _messageRepository.GetMessagesByTime(request.ByUserName, request.ToUserName, request.HourFrom, request.HourTo, request.Day);

            }
        }
    }
}
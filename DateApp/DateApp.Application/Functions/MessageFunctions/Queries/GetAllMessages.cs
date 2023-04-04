using Domain.Interfaces.Repositories;

namespace Application.Functions.MessageFunctions.Queries
{
    public class GetAllMessagesQuery : IRequest<List<UserMessage>>
    {
        public string? ByUserName { get; set; }
        public string? ToUserName { get; set; }

        public class GetAllMessages : IRequestHandler<GetAllMessagesQuery, List<UserMessage>>
        {


            private readonly IMessageRepository _messageRepository;

            public GetAllMessages(IMessageRepository messageRepository)
            {
                _messageRepository = messageRepository;

            }


            async Task<List<UserMessage>> IRequestHandler<GetAllMessagesQuery, List<UserMessage>>.Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
            {

                return await _messageRepository.getAllMessages(request.ByUserName, request.ToUserName);



                // var messagesDto = _mapper.Map<List<UserMessage>, List<MessageDto>>(messages);

                // return PagedList<MessageDto>.ToPagedList(messagesDto,
                //  request.PaginationParams.PageNumber,
                //  request.PaginationParams.PageSize);
            }
        }
    }
}
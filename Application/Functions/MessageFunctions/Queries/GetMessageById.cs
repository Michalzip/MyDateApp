using Domain.Interfaces.Repositories;

namespace DateApp.Functions.MessageFunctions.Queries
{
    public class GetMessageByIdQuery : IRequest<UserMessage>
    {

        public int Id { get; set; }


        public class GetMessageById : IRequestHandler<GetMessageByIdQuery, UserMessage>
        {
            private readonly IMessageRepository _messageRepository;
            public GetMessageById(IMessageRepository messageRepository)
            {
                _messageRepository = messageRepository;
            }

            async Task<UserMessage> IRequestHandler<GetMessageByIdQuery, UserMessage>.Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
            {
                return await _messageRepository.GetMessageById(request.Id);


            }
        }
    }


}
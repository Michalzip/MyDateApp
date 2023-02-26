using Domain.Interfaces.Repositories;

namespace DateApp.Functions.MessageFunctions.Commands
{

    public class CreateMessageCommand : IRequest<int>
    {
        public UserProfile? ByUser { get; set; }
        public UserProfile? ToUser { get; set; }
        public string? Message { get; set; }



        public class CreateMessage : IRequestHandler<CreateMessageCommand, int>
        {
            private readonly IMessageRepository _messageRepository;

            public CreateMessage(IMessageRepository messageRepository)
            {
                _messageRepository = messageRepository;

            }



            async Task<int> IRequestHandler<CreateMessageCommand, int>.Handle(CreateMessageCommand request, CancellationToken cancellationToken)
            {

                var message = new UserMessage
                {
                    ByUser = request.ByUser,
                    ToUser = request.ToUser,
                    Message = request.Message,

                };

                _messageRepository.Add(message);

                return _messageRepository.SaveChanges();



            }
        }
    }
}
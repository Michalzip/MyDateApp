using Domain.Interfaces.Repositories;

namespace Application.Functions.MessageFunctions.Commands
{

    public class CreateMessageCommand : IRequest<int>
    {

        public UserMessage? Message { get; set; }

        public class CreateMessage : IRequestHandler<CreateMessageCommand, int>
        {
            private readonly IMessageRepository _messageRepository;

            public CreateMessage(IMessageRepository messageRepository)
            {
                _messageRepository = messageRepository;

            }



            async Task<int> IRequestHandler<CreateMessageCommand, int>.Handle(CreateMessageCommand request, CancellationToken cancellationToken)
            {

                _messageRepository.add(request.Message);

                return _messageRepository.saveChanges();



            }
        }
    }
}
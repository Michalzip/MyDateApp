using Domain.Interfaces.Repositories;

namespace DateApp.Functions.MessageFunctions.Commands
{

    public class DeleteMessageByIdCommand : IRequest<int>
    {

        public UserMessage? UserMessage { get; set; }

        public class DeleteMessageById : IRequestHandler<DeleteMessageByIdCommand, int>
        {

            private readonly IMessageRepository _messageRepository;

            public DeleteMessageById(IMessageRepository messageRepository)
            {
                _messageRepository = messageRepository;


            }

            async Task<int> IRequestHandler<DeleteMessageByIdCommand, int>.Handle(DeleteMessageByIdCommand request, CancellationToken cancellationToken)
            {


                _messageRepository.Remove(request.UserMessage);

                return _messageRepository.SaveChanges();


            }
        }

    }
}

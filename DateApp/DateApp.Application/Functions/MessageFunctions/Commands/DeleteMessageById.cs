using Domain.Interfaces.Repositories;

namespace Application.Functions.MessageFunctions.Commands
{

    public class DeleteMessageByIdCommand : IRequest<int>
    {

        public int Id { get; set; }

        public class DeleteMessageById : IRequestHandler<DeleteMessageByIdCommand, int>
        {

            private readonly IMessageRepository _messageRepository;

            public DeleteMessageById(IMessageRepository messageRepository)
            {
                _messageRepository = messageRepository;


            }

            async Task<int> IRequestHandler<DeleteMessageByIdCommand, int>.Handle(DeleteMessageByIdCommand request, CancellationToken cancellationToken)
            {

                var message = await _messageRepository.getMessageById(request.Id);

                _messageRepository.remove(message);

                return _messageRepository.saveChanges();


            }
        }

    }
}

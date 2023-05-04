namespace DateApp.Domain.Functions.MessageFunctions.Commands
{
    public class DeleteMessageByIdCommand : IRequest<int>
    {
        public UserMessage? Message { get; set; }

        public class DeleteMessageById : IRequestHandler<DeleteMessageByIdCommand, int>
        {
            private readonly IMessageRepository _messageRepository;

            public DeleteMessageById(IMessageRepository messageRepository)
            {
                _messageRepository = messageRepository;
            }

            async Task<int> IRequestHandler<DeleteMessageByIdCommand, int>.Handle(DeleteMessageByIdCommand request, CancellationToken cancellationToken)
            {
                _messageRepository.remove(request.Message);

                return _messageRepository.saveChanges();
            }
        }
    }
}

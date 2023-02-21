namespace DateApp.Functions.MessageFunctions.Commands
{

    public class DeleteMessageByIdCommand : IRequest<int>
    {

        public UserMessage? UserMessage { get; set; }

        public class DeleteMessageById : IRequestHandler<DeleteMessageByIdCommand, int>
        {

            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public DeleteMessageById(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            async Task<int> IRequestHandler<DeleteMessageByIdCommand, int>.Handle(DeleteMessageByIdCommand request, CancellationToken cancellationToken)
            {


                _context.UserMessages.Remove(request.UserMessage);

                return await _context.SaveChangesAsync();

            }
        }

    }
}

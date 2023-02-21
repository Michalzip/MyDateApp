namespace DateApp.Functions.MessageFunctions.Commands
{

    public class CreateMessageCommand : IRequest<int>
    {
        public UserProfile? ByUser { get; set; }
        public UserProfile? ToUser { get; set; }
        public string? Message { get; set; }



        public class CreateMessage : IRequestHandler<CreateMessageCommand, int>
        {
            private readonly AppDbContext _context;

            public CreateMessage(AppDbContext context)
            {
                _context = context;

            }



            async Task<int> IRequestHandler<CreateMessageCommand, int>.Handle(CreateMessageCommand request, CancellationToken cancellationToken)
            {

                var message = new UserMessage
                {
                    ByUser = request.ByUser,
                    ToUser = request.ToUser,
                    Message = request.Message,

                };

                await _context.AddAsync(message);

                return await _context.SaveChangesAsync();

            }
        }
    }
}
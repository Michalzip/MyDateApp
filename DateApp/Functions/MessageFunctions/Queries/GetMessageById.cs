namespace DateApp.Functions.MessageFunctions.Queries
{
    public class GetMessageByIdQuery : IRequest<UserMessage>
    {

        public int Id { get; set; }


        public class GetMessageById : IRequestHandler<GetMessageByIdQuery, UserMessage>
        {
            private readonly AppDbContext _context;
            public GetMessageById(AppDbContext context)
            {
                _context = context;
            }

            async Task<UserMessage> IRequestHandler<GetMessageByIdQuery, UserMessage>.Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
            {
                return await _context.UserMessages
                .Include(u => u.ByUser)
                .Include(u => u.ToUser)
                .SingleOrDefaultAsync(x => x.Id == request.Id);


            }
        }
    }


}
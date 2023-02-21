namespace DateApp.Functions.MessageFunctions.Queries
{
    public class GetAllMessagesQuery : IRequest<List<UserMessage>>
    {
        public string? ByUserName { get; set; }
        public string? ToUserName { get; set; }

        public class GetAllMessages : IRequestHandler<GetAllMessagesQuery, List<UserMessage>>
        {


            private readonly AppDbContext _context;

            public GetAllMessages(AppDbContext context)
            {
                _context = context;

            }


            async Task<List<UserMessage>> IRequestHandler<GetAllMessagesQuery, List<UserMessage>>.Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
            {
                return await _context.UserMessages
               .Include(x => x.ByUser)
               .Include(x => x.ToUser)
               .Where(u => u.ByUser.UserName == request.ByUserName && u.ToUser.UserName == request.ToUserName
                || u.ByUser.UserName == request.ToUserName && u.ToUser.UserName == request.ByUserName
               )
               .ToListAsync();



                // var messagesDto = _mapper.Map<List<UserMessage>, List<MessageDto>>(messages);

                // return PagedList<MessageDto>.ToPagedList(messagesDto,
                //  request.PaginationParams.PageNumber,
                //  request.PaginationParams.PageSize);
            }
        }
    }
}
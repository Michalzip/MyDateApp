namespace DateApp.Functions.MessageFunctions.Queries
{
    public class GetMessageByTimeQuery : IRequest<List<UserMessage>>
    {
        public string? ByUserName { get; set; }
        public string? ToUserName { get; set; }
        public int HourFrom { get; set; }
        public int HourTo { get; set; }
        public int Day { get; set; }

        public class GetMessageByTime : IRequestHandler<GetMessageByTimeQuery, List<UserMessage>>
        {

            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public GetMessageByTime(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            async Task<List<UserMessage>> IRequestHandler<GetMessageByTimeQuery, List<UserMessage>>.Handle(GetMessageByTimeQuery request, CancellationToken cancellationToken)
            {
                return await _context.UserMessages
                .Include(x => x.ByUser)
                .Include(x => x.ToUser)
                .Where(u => u.CreatedAt.Hour >= request.HourFrom && u.CreatedAt.Hour <= request.HourTo && u.CreatedAt.Day == request.Day
                && u.ByUser.UserName == request.ByUserName && u.ToUser.UserName == request.ToUserName
                || u.ByUser.UserName == request.ToUserName && u.ToUser.UserName == request.ByUserName

                ).ToListAsync();

            }
        }
    }
}
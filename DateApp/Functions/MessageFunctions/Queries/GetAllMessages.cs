using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateApp.Helpers;

namespace DateApp.Functions.MessageFunctions.Queries
{
    public class GetAllMessagesQuery : IRequest<PagedList<MessageDto>>
    {
        public string? ByUserName { get; set; }
        public string? ToUserName { get; set; }
        public PaginationParams? PaginationParams { get; set; }
        public class GetAllMessages : IRequestHandler<GetAllMessagesQuery, PagedList<MessageDto>>
        {


            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public GetAllMessages(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            async Task<PagedList<MessageDto>> IRequestHandler<GetAllMessagesQuery, PagedList<MessageDto>>.Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
            {
                var messages = await _context.UserMessages
              .Include(x => x.ByUser)
              .Include(x => x.ToUser)
              .Where(u => u.ByUser.UserName == request.ByUserName && u.ToUser.UserName == request.ToUserName
               || u.ByUser.UserName == request.ToUserName && u.ToUser.UserName == request.ByUserName
              )
              .ToListAsync();

                var messagesDto = _mapper.Map<List<UserMessage>, List<MessageDto>>(messages);

                return PagedList<MessageDto>.ToPagedList(messagesDto,
                 request.PaginationParams.PageNumber,
                 request.PaginationParams.PageSize);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateApp.Functions.MessageFunctions.Queries
{
    public class GetMessageByTimeQuery : IRequest<List<MessageDto>>
    {
        public string? ByUserName { get; set; }
        public string? ToUserName { get; set; }
        public int HourFrom { get; set; }
        public int HourTo { get; set; }
        public int Day { get; set; }

        public class GetMessageByTime : IRequestHandler<GetMessageByTimeQuery, List<MessageDto>>
        {

            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public GetMessageByTime(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            async Task<List<MessageDto>> IRequestHandler<GetMessageByTimeQuery, List<MessageDto>>.Handle(GetMessageByTimeQuery request, CancellationToken cancellationToken)
            {
                var messages = await _context.UserMessages
              .Include(x => x.ByUser)
              .Include(x => x.ToUser)
              .Where(u => u.CreatedAt.Hour >= request.HourFrom && u.CreatedAt.Hour <= request.HourTo && u.CreatedAt.Day == request.Day
              && u.ByUser.UserName == request.ByUserName && u.ToUser.UserName == request.ToUserName
              || u.ByUser.UserName == request.ToUserName && u.ToUser.UserName == request.ByUserName
              && u.CreatedAt.Hour >= request.HourFrom && u.CreatedAt.Hour <= request.HourTo && u.CreatedAt.Day == request.Day
              ).ToListAsync();

                var messagesDto = _mapper.Map<List<UserMessage>, List<MessageDto>>(messages);

                return messagesDto;


            }


        }
    }
}
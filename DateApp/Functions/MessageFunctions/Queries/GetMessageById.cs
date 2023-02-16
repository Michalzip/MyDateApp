using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                var message = await _context.UserMessages
                .Include(u => u.ByUser)
                .Include(u => u.ToUser)
                .SingleOrDefaultAsync(x => x.Id == request.Id);

                if (message == null) return null;

                return message;
            }
        }
    }


}
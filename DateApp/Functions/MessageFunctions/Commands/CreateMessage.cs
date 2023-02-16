using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateApp.Functions.MessageFunctions.Commands
{

    public class CreateMessageCommand : IRequest<MessageDto>
    {
        public UserProfile? ByUser { get; set; }
        public UserProfile? ToUser { get; set; }
        public string? Message { get; set; }



        public class CreateMessage : IRequestHandler<CreateMessageCommand, MessageDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public CreateMessage(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }



            async Task<MessageDto> IRequestHandler<CreateMessageCommand, MessageDto>.Handle(CreateMessageCommand request, CancellationToken cancellationToken)
            {

                var message = new UserMessage
                {
                    ByUser = request.ByUser,
                    ToUser = request.ToUser,
                    Message = request.Message,

                };

                await _context.AddAsync(message);

                var result = await _context.SaveChangesAsync();

                if (result == 0) return null;

                return _mapper.Map<UserMessage, MessageDto>(message);
            }
        }
    }
}
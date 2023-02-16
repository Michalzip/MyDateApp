using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateApp.Functions.MessageFunctions.Commands
{

    public class DeleteMessageByIdCommand : IRequest<bool>
    {

        public int Id { get; set; }

        public class DeleteMessageById : IRequestHandler<DeleteMessageByIdCommand, bool>
        {

            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public DeleteMessageById(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            async Task<bool> IRequestHandler<DeleteMessageByIdCommand, bool>.Handle(DeleteMessageByIdCommand request, CancellationToken cancellationToken)
            {

                var message = new UserMessage
                {
                    Id = request.Id,
                };

                _context.UserMessages.Remove(message);

                var result = await _context.SaveChangesAsync();

                if (result == 0) return false;

                return true;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DateApp.Functions.LikeFunctions.Commands
{


    public class CreateLikeCommand : IRequest<LikeDto>
    {
        public UserProfile? ByUser { get; set; }
        public UserProfile? ToUser { get; set; }



        public class CreateLike : IRequestHandler<CreateLikeCommand, LikeDto>
        {



            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public CreateLike(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            async Task<LikeDto> IRequestHandler<CreateLikeCommand, LikeDto>.Handle(CreateLikeCommand request, CancellationToken cancellationToken)
            {
   

                var like = new UserLike
                {
                    ByUser = request.ByUser,
                    ToUser = request.ToUser,
                };


                await _context.AddAsync(like);

                await _context.SaveChangesAsync();

                return _mapper.Map<UserLike, LikeDto>(like);


            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateApp.Functions.LikeFunctions.Queries
{

    public class GetLikesUserQuery : IRequest<List<LikeDto>>
    {

        public string? sourceUser { get; set; }



        public class GetLikeUser : IRequestHandler<GetLikesUserQuery, List<LikeDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public GetLikeUser(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }




            async Task<List<LikeDto>> IRequestHandler<GetLikesUserQuery, List<LikeDto>>.Handle(GetLikesUserQuery request, CancellationToken cancellationToken)
            {
                //users that you like.
                var likesUsers = await _context.UserLikes.Where(u => u.ToUser.UserName == request.sourceUser).ToListAsync();

                if (likesUsers == null) return null;

                return _mapper.Map<List<UserLike>, List<LikeDto>>(likesUsers);



            }
        }
    }
}
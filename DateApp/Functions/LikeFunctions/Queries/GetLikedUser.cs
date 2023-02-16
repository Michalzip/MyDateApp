using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateApp.Functions.LikeFunctions.Queries
{

    public class GetLikedUserQuery : IRequest<List<LikeDto>>
    {

        public string? sourceUser { get; set; }
        public class GetLikedUser : IRequestHandler<GetLikedUserQuery, List<LikeDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public GetLikedUser(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            async Task<List<LikeDto>> IRequestHandler<GetLikedUserQuery, List<LikeDto>>.Handle(GetLikedUserQuery request, CancellationToken cancellationToken)
            {
                //users that liked your account.
                var likedUsers = await _context.UserLikes.Where(u => u.ByUser.UserName == request.sourceUser).ToListAsync();

                if (likedUsers == null) return null;

                return _mapper.Map<List<UserLike>, List<LikeDto>>(likedUsers);

            }
        }
    }
}
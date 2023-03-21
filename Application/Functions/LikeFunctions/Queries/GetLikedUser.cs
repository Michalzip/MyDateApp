
using Domain.Interfaces.Repositories;

namespace Application.Functions.LikeFunctions.Queries
{

    public class GetLikedUserQuery : IRequest<List<UserLike>>
    {

        public string? ByUserName { get; set; }
        public class GetLikedUser : IRequestHandler<GetLikedUserQuery, List<UserLike>>
        {
            private readonly ILikeRepository _likeRepository;

            public GetLikedUser(ILikeRepository likeRepository)
            {
                _likeRepository = likeRepository;

            }

            async Task<List<UserLike>> IRequestHandler<GetLikedUserQuery, List<UserLike>>.Handle(GetLikedUserQuery request, CancellationToken cancellationToken)
            {
                //users that liked your account.
                return await _likeRepository.getLikedUsers(request.ByUserName);

            }
        }
    }
}
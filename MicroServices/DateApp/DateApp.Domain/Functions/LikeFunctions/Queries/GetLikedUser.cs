
using Domain.Interfaces.Repositories;

namespace DateApp.Domain.Functions.LikeFunctions.Queries
{

    internal class GetLikedUserQuery : IRequest<List<UserLike>>
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
                //users that you liked.
                return await _likeRepository.getLikedUsers(request.ByUserName);

            }
        }
    }
}
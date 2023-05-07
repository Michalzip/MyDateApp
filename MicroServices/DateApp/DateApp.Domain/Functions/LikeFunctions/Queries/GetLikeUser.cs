
namespace DateApp.Domain.Functions.LikeFunctions.Queries
{
    internal class GetLikesUserQuery : IRequest<List<UserLike>>
    {
        public string? ByUserName { get; set; }
        public class GetLikeUser : IRequestHandler<GetLikesUserQuery, List<UserLike>>
        {
            private readonly ILikeRepository _likeRepository;

            public GetLikeUser(ILikeRepository likeRepository)
            {
                _likeRepository = likeRepository;
            }

            async Task<List<UserLike>> IRequestHandler<GetLikesUserQuery, List<UserLike>>.Handle(GetLikesUserQuery request, CancellationToken cancellationToken)
            {
                //users that your profile.
                return await _likeRepository.getLikeUsers(request.ByUserName);
            }
        }
    }
}
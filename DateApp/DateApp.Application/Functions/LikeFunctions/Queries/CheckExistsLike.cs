
using Domain.Interfaces.Repositories;

namespace Application.Functions.LikeFunctions.Queries
{

    public class CheckExistLikeByUserNameQuery : IRequest<bool>
    {

        public string? ByUserName { get; set; }

        public string? ToUserName { get; set; }

        public class CheckExistsLike : IRequestHandler<CheckExistLikeByUserNameQuery, bool>
        {
            private readonly ILikeRepository _likeRepository;
            public CheckExistsLike(ILikeRepository likeRepository)
            {
                _likeRepository = likeRepository;

            }


            async Task<bool> IRequestHandler<CheckExistLikeByUserNameQuery, bool>.Handle(CheckExistLikeByUserNameQuery request, CancellationToken cancellationToken)
            {
                return await _likeRepository.existsLike(request.ByUserName, request.ToUserName);

            }
        }

    }

}
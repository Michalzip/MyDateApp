using Api.Entities;
using Domain.Interfaces.Repositories;

namespace DateApp.Functions.LikeFunctions.Commands
{


    public class CreateLikeCommand : IRequest<int>
    {
        public UserProfile? ByUser { get; set; }
        public UserProfile? ToUser { get; set; }



        public class CreateLike : IRequestHandler<CreateLikeCommand, int>
        {



            private readonly ILikeRepository _likeRepository;


            public CreateLike(ILikeRepository likeRepository)
            {
                _likeRepository = likeRepository;

            }

            async Task<int> IRequestHandler<CreateLikeCommand, int>.Handle(CreateLikeCommand request, CancellationToken cancellationToken)
            {


                var like = new UserLike
                {
                    ByUser = request.ByUser,
                    ToUser = request.ToUser,
                };

                _likeRepository.Add(like);

                return _likeRepository.SaveChanges();

            }

        }
    }
}

using Domain.Interfaces.Repositories;

namespace Application.Functions.LikeFunctions.Commands
{


    public class CreateLikeCommand : IRequest<int>
    {

        public UserLike? Like { get; set; }



        public class CreateLike : IRequestHandler<CreateLikeCommand, int>
        {


            private readonly ILikeRepository _likeRepository;


            public CreateLike(ILikeRepository likeRepository)
            {
                _likeRepository = likeRepository;

            }

            async Task<int> IRequestHandler<CreateLikeCommand, int>.Handle(CreateLikeCommand request, CancellationToken cancellationToken)
            {

                //zapytanie do bazy danycch
                //pobieram dwoch userow 

                _likeRepository.add(request.Like);

                return _likeRepository.saveChanges();

            }

        }
    }
}
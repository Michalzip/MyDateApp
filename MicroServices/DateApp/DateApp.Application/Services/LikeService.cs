using Application.Functions.LikeFunctions.Queries;
using Application.Functions.LikeFunctions.Commands;
using Application.Interfaces.Services;


namespace Application.Services
{
    public class LikeService : ILikeService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LikeService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //stworzyc exceptions
        //wywołac go tutaj
        //np userProfileNotFOundExpections


        //robic servicy do wszytskiego a nie wywolywac bezposrednio mediator w kontrolerze 


        //a w kontrolerze uzyc np Error result
        //np [ProducesResponseType(typeof(nazwa klasy np ErrorResult), StatusCodes.Status200OK)]
        //kontrooler 

        public async Task<int> CreateLikeFromQuery(string byUser, string toUser)
        {



            var byUserProfile = await _mediator.Send(new GetUserByNameQuery { UserName = byUser });

            var toUserProfile = await _mediator.Send(new GetUserByNameQuery { UserName = toUser });

            if (toUserProfile == null) return 0; //zamiast return throw new ToUserProfileNotFoundException("User not found");


            var exitLike = await _mediator.Send(new CheckExistLikeByUserNameQuery { ByUserName = byUserProfile.UserName, ToUserName = toUserProfile.UserName });

            if (exitLike) return 0;

            var like = new UserLike
            {
                ByUser = byUserProfile,
                ToUser = toUserProfile
            };

            return await _mediator.Send(new CreateLikeCommand { Like = like });

        }



        public async Task<List<LikeDto>> GetLikesProfiles(string byUser)
        {

            var likeProfiles =  await _mediator.Send(new GetLikesUserQuery { ByUserName = byUser });

            return _mapper.Map<List<UserLike>, List<LikeDto>>(likeProfiles); 


        }


        public async Task<List<LikeDto>> GetLikedProfiles(string byUser)
        {


            var likedProfiles =  await _mediator.Send(new GetLikedUserQuery { ByUserName = byUser });

            return _mapper.Map<List<UserLike>, List<LikeDto>>(likedProfiles);



        }

    }
}
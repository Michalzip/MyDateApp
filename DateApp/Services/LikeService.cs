
using DateApp.Services.Interfaces;
using DateApp.Functions.LikeFunctions.Queries;
using DateApp.Functions.LikeFunctions.Commands;

namespace DateApp.Services
{
    public class LikeService : ILikeService
    {
        private readonly IMediator _mediator;
        public LikeService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<LikeDto> CreateLikeFromQuery(string byUser, string toUser)
        {


            var user1 = new GetUserByNameQuery
            {
                userName = byUser
            };


            var byUserProfile = await _mediator.Send(user1);


            var user2 = new GetUserByNameQuery
            {
                userName = toUser
            };

            var toUserProfile = await _mediator.Send(user2);

            var users = new CheckExistLikeByUserNameQuery
            {

                sourceUser = byUserProfile.UserName,
                receiverUser = toUserProfile.UserName
            };

            var exitLike = await _mediator.Send(users);

            if (exitLike) return null;

            var like = new CreateLikeCommand
            {
                ByUser = byUserProfile,
                ToUser = toUserProfile

            };

            return await _mediator.Send(like);



        }



        public async Task<List<LikeDto>> GetLikesProfiles(string byUser)
        {




            var likesProfiles = new GetLikedUserQuery
            {

                sourceUser = byUser
            };

            return await _mediator.Send(likesProfiles);

        }


        public async Task<List<LikeDto>> GetLikedProfiles(string byUser)
        {


            var likedProfiles = new GetLikedUserQuery
            {

                sourceUser = byUser
            };

            return await _mediator.Send(likedProfiles);



        }




    }
}
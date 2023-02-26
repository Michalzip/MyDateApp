using DateApp.Functions.LikeFunctions.Queries;
using DateApp.Functions.LikeFunctions.Commands;
using Domain.Interfaces.Services;


namespace DateApp.Services
{
    public class LikeService : ILikeService
    {
        private readonly IMediator _mediator;
        public LikeService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<int> CreateLikeFromQuery(string byUser, string toUser)
        {


            var user1 = new GetUserByNameQuery
            {
                UserName = byUser
            };


            var byUserProfile = await _mediator.Send(user1);


            var user2 = new GetUserByNameQuery
            {
                UserName = toUser
            };



            var toUserProfile = await _mediator.Send(user2);

            if (toUserProfile == null) return 0;

            var users = new CheckExistLikeByUserNameQuery
            {

                ByUserName = byUserProfile.UserName,
                ToUserName = toUserProfile.UserName
            };

            var exitLike = await _mediator.Send(users);

            if (exitLike) return 0;

            var like = new CreateLikeCommand
            {
                ByUser = byUserProfile,
                ToUser = toUserProfile

            };

            return await _mediator.Send(like);


        }



        public async Task<List<UserLike>> GetLikesProfiles(string byUser)
        {


            var likesProfiles = new GetLikesUserQuery
            {

                ByUserName = byUser
            };

            return await _mediator.Send(likesProfiles);

        }


        public async Task<List<UserLike>> GetLikedProfiles(string byUser)
        {


            var likedProfiles = new GetLikedUserQuery
            {

                ByUserName = byUser
            };

            return await _mediator.Send(likedProfiles);



        }

    }
}
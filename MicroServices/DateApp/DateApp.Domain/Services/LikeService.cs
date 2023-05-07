using DateApp.Domain.Functions.LikeFunctions.Queries;
using DateApp.Domain.Functions.LikeFunctions.Commands;

namespace DateApp.Domain.Services
{
    internal class LikeService : ILikeService
    {
        private readonly IMediator _mediator;

        public LikeService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task CreateLikeFromQuery(string byUser, string toUser)
        {
            var byUserProfile = await _mediator.Send(new GetUserByNameQuery { UserName = byUser });

            var toUserProfile = await _mediator.Send(new GetUserByNameQuery { UserName = toUser });

            if (toUserProfile == null) throw new NotFoundException("user not found");

            var exitLike = await _mediator.Send(new CheckExistLikeByUserNameQuery { ByUserName = byUserProfile.UserName, ToUserName = toUserProfile.UserName });

            if (exitLike) throw new AlreadyExistsException("like already exists");

            var like = new UserLike
            {
                ByUser = byUserProfile,
                ToUser = toUserProfile
            };

            var result = await _mediator.Send(new CreateLikeCommand { Like = like });

            if (result == 0) throw new FailedOperationException("failed to create like");
        }
        public async Task<List<UserLike>> GetLikesProfiles(string byUser)
        {
            return await _mediator.Send(new GetLikesUserQuery { ByUserName = byUser });
        }

        public async Task<List<UserLike>> GetLikedProfiles(string byUser)
        {
            return await _mediator.Send(new GetLikedUserQuery { ByUserName = byUser });
        }
    }
}
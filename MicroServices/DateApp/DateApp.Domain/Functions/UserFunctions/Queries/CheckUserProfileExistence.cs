namespace DateApp.Domain.Functions.UserFunctions.Queries
{
    public class CheckUserProfileExistenceQuery : IRequest<bool>
    {
        public string Id { get; set; }
    }

    public class CheckUserProfileExistence : IRequestHandler<CheckUserProfileExistenceQuery, bool>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public CheckUserProfileExistence(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        async Task<bool> IRequestHandler<CheckUserProfileExistenceQuery, bool>.Handle(CheckUserProfileExistenceQuery request, CancellationToken cancellationToken)
        {
            return _userProfileRepository.ExistsUserProfile(request.Id);
        }
    }
}

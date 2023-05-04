namespace DateApp.Domain.Functions.UserFunctions.Queries
{
    public class GetUserByNameQuery : IRequest<UserProfile>
    {
        public string? UserName { get; set; }
    }

    public class GetUserByName : IRequestHandler<GetUserByNameQuery, UserProfile>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public GetUserByName(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        async Task<UserProfile> IRequestHandler<GetUserByNameQuery, UserProfile>.Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            return await _userProfileRepository.getUserProfileByName(request.UserName);
        }
    }
}
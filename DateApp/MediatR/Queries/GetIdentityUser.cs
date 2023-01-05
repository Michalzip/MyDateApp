
namespace Api.MediatR.Queries
{

    public class GetIdentityUserQueryHandler : IRequestHandler<UserCreateProfileDto, UserProfile>
    {
        private readonly IIdentityUserRepo _identityUserRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetIdentityUserQueryHandler(IIdentityUserRepo identityUserRepo, IHttpContextAccessor httpContextAccessor)
        {
            _identityUserRepo = identityUserRepo;
            _httpContextAccessor = httpContextAccessor;
        }



        async Task<UserProfile> IRequestHandler<UserCreateProfileDto, UserProfile>.Handle(UserCreateProfileDto request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var identityUser = await _identityUserRepo.GetIdentityUserById(userId); 
            
            var user = new UserProfile
            {
                UserId = identityUser.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = identityUser.UserName,
                PhotoUrl = request.PhotoUrl,


            };

            return user;
    
        }

    }
}


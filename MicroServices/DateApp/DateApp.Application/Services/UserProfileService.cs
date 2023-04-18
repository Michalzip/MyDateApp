using Application.Functions.UserFunctions.Commands;
using Application.Interfaces.Services;
using DateApp.Domain.Interfaces.Messages;
using DateApp.Infrastructure.Rpc;

namespace Application.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IMediator _mediator;



        private readonly RpcClient _rpcClient;
        private readonly IMapper _mapper;

        public UserProfileService(IMediator mediator, IMapper mapper, RpcClient rpcClient)
        {
            _mediator = mediator;
            // _identityUserService = identityUserService;
            // _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;

            _rpcClient = rpcClient;
        }



        public async Task<int> CreateUserProfile(string firstName, string lastName, string photoUrl)
        {

            //zwriclo mi ID, USERNAME Z ApplicationUser
            var ApplicationUser = await _rpcClient.CallAsync(firstName);

            Console.WriteLine("Dane ktore przyszly z IdentityServer" + ApplicationUser);

            // var sourceUserName = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);



            // return await _mediator.Send(new CreateUserCommand
            // {
            //     User = new UserProfile
            //     {
            //         Id = identityUser.Id,
            //         FirstName = firstName,
            //         LastName = lastName,
            //         UserName = identityUser.UserName,
            //         PhotoUrl = photoUrl,
            //     }
            // });

            return 1;

        }


        public async Task<UserProfileDto> GetUserProfile(string username)
        {

            var userProfile = await _mediator.Send(new GetUserByNameQuery { UserName = username });

            return _mapper.Map<UserProfile, UserProfileDto>(userProfile);
        }

    }
}
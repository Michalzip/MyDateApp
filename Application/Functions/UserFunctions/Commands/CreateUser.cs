using Domain.Interfaces.Repositories;

namespace DateApp.Functions.UserFunctions.Commands
{
    public class CreateUserCommand : IRequest<int>
    {

        public UserProfile? User { get; set; }
        public class CreateUser : IRequestHandler<CreateUserCommand, int>
        {
            private readonly IUserProfileRepository _userProfileRepository;

            public CreateUser(IUserProfileRepository userProfileRepository)
            {
                _userProfileRepository = userProfileRepository;

            }



            async Task<int> IRequestHandler<CreateUserCommand, int>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                _userProfileRepository.Add(request.User);

                return _userProfileRepository.SaveChanges();

            }
        }

    }
}
namespace Server.Functions.UserFunctions.Queries
{
    public class GetUserByEmailQuery : IRequest<ApplicationUser>
    {
        public string? Email { get; set; }

        public class GetUserByEmail : IRequestHandler<GetUserByEmailQuery, ApplicationUser>
        {
            private readonly UserManager<ApplicationUser> _userManager;

            public GetUserByEmail(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }

            async Task<ApplicationUser> IRequestHandler<GetUserByEmailQuery, ApplicationUser>.Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
            {
                return await _userManager.FindByEmailAsync(request.Email);

            }
        }
    }
}
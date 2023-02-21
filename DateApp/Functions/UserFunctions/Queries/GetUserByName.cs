namespace DateApp.Functions.UserFunctions.Queries
{


    public class GetUserByNameQuery : IRequest<UserProfile>
    {
        public string? UserName { get; set; }
        public class GetUserByName : IRequestHandler<GetUserByNameQuery, UserProfile>
        {
            private readonly AppDbContext _context;

            public GetUserByName(AppDbContext context)
            {
                _context = context;

            }

            async Task<UserProfile> IRequestHandler<GetUserByNameQuery, UserProfile>.Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
            {
                return await _context.UserProfiles.Where(u => u.UserName == request.UserName).FirstOrDefaultAsync();




            }


        }


    }
}
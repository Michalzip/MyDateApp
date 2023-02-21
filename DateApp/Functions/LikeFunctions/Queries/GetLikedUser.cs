namespace DateApp.Functions.LikeFunctions.Queries
{

    public class GetLikedUserQuery : IRequest<List<UserLike>>
    {

        public string? sourceUser { get; set; }
        public class GetLikedUser : IRequestHandler<GetLikedUserQuery, List<UserLike>>
        {
            private readonly AppDbContext _context;

            public GetLikedUser(AppDbContext context)
            {
                _context = context;

            }

            async Task<List<UserLike>> IRequestHandler<GetLikedUserQuery, List<UserLike>>.Handle(GetLikedUserQuery request, CancellationToken cancellationToken)
            {
                //users that liked your account.
                return await _context.UserLikes.Where(u => u.ByUser.UserName == request.sourceUser).ToListAsync();

            }
        }
    }
}
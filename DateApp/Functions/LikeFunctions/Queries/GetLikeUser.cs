namespace DateApp.Functions.LikeFunctions.Queries
{

    public class GetLikesUserQuery : IRequest<List<UserLike>>
    {

        public string? sourceUser { get; set; }



        public class GetLikeUser : IRequestHandler<GetLikesUserQuery, List<UserLike>>
        {
            private readonly AppDbContext _context;

            public GetLikeUser(AppDbContext context)
            {
                _context = context;

            }




            async Task<List<UserLike>> IRequestHandler<GetLikesUserQuery, List<UserLike>>.Handle(GetLikesUserQuery request, CancellationToken cancellationToken)
            {
                //users that you like.
                return await _context.UserLikes.Where(u => u.ToUser.UserName == request.sourceUser).ToListAsync();


            }
        }
    }
}
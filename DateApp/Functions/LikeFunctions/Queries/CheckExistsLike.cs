namespace DateApp.Functions.LikeFunctions.Queries
{

    public class CheckExistLikeByUserNameQuery : IRequest<bool>
    {

        public string? sourceUser { get; set; }

        public string? receiverUser { get; set; }

        public class CheckExistsLike : IRequestHandler<CheckExistLikeByUserNameQuery, bool>
        {
            private readonly AppDbContext _context;
            public CheckExistsLike(AppDbContext context)
            {
                _context = context;

            }


            async Task<bool> IRequestHandler<CheckExistLikeByUserNameQuery, bool>.Handle(CheckExistLikeByUserNameQuery request, CancellationToken cancellationToken)
            {
                var likesUser = await _context.UserLikes
             .Where(u => u.ByUser.UserName == request.sourceUser)
             .AnyAsync(u => u.ToUser.UserName == request.receiverUser);


                return likesUser;



            }
        }

    }

}
namespace DateApp.Functions.LikeFunctions.Commands
{


    public class CreateLikeCommand : IRequest<int>
    {
        public UserProfile? ByUser { get; set; }
        public UserProfile? ToUser { get; set; }



        public class CreateLike : IRequestHandler<CreateLikeCommand, int>
        {



            private readonly AppDbContext _context;


            public CreateLike(AppDbContext context)
            {
                _context = context;

            }

            async Task<int> IRequestHandler<CreateLikeCommand, int>.Handle(CreateLikeCommand request, CancellationToken cancellationToken)
            {


                var like = new UserLike
                {
                    ByUser = request.ByUser,
                    ToUser = request.ToUser,
                };


                await _context.AddAsync(like);

                return await _context.SaveChangesAsync();




            }

        }
    }
}
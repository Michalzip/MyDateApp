namespace DateApp.Functions.UserFunctions.Commands
{
    public class CreateUserCommand : IRequest<int>
    {

        public UserProfile? User { get; set; }
        public class CreateUser : IRequestHandler<CreateUserCommand, int>
        {
            private readonly AppDbContext _context;

            public CreateUser(AppDbContext context)
            {
                _context = context;

            }



            async Task<int> IRequestHandler<CreateUserCommand, int>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                await _context.AddAsync(request.User);

                return await _context.SaveChangesAsync();

            }
        }

    }
}
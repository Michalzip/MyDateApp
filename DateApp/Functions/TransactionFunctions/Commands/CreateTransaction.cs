
namespace DateApp.Functions.TransactionFunctions.Commands
{
    public class CreateTransactionCommand : IRequest<int>
    {
        public UserTransaction? UserTransaction { get; set; }

        public class CreateTransaction : IRequestHandler<CreateTransactionCommand, int>
        {
            private readonly AppDbContext _context;

            public CreateTransaction(AppDbContext context)
            {
                _context = context;
            }



            async Task<int> IRequestHandler<CreateTransactionCommand, int>.Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
            {

                await _context.AddAsync(request.UserTransaction);

                return await _context.SaveChangesAsync();
            }
        }

    }
}

namespace DateApp.Functions.TransactionFunctions.Queries
{
    public class GetLastTransactionQuery : IRequest<UserTransaction>
    {

        public class GetLastTransaction : IRequestHandler<GetLastTransactionQuery, UserTransaction>
        {
            private readonly AppDbContext _context;
            public GetLastTransaction(AppDbContext context)
            {
                _context = context;
            }

            async Task<UserTransaction> IRequestHandler<GetLastTransactionQuery, UserTransaction>.Handle(GetLastTransactionQuery request, CancellationToken cancellationToken)
            {
                return await _context.Transactions.OrderByDescending(u => u.Id).FirstOrDefaultAsync();
            }
        }
    }
}
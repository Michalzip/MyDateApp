namespace DateApp.Functions.TransactionFunctions.Queries
{
    public class GetSuccessTransactionsQuery : IRequest<List<UserTransaction>>
    {


        public class GetSuccessTransactions : IRequestHandler<GetSuccessTransactionsQuery, List<UserTransaction>>
        {
            private readonly AppDbContext _context;
            public GetSuccessTransactions(AppDbContext context)
            {
                _context = context;
            }

            async Task<List<UserTransaction>> IRequestHandler<GetSuccessTransactionsQuery, List<UserTransaction>>.Handle(GetSuccessTransactionsQuery request, CancellationToken cancellationToken)
            {
                return _context.Transactions.Where(u => u.Success == true).ToList();
            }
        }
    }
}

namespace DateApp.Domain.Functions.TransactionFunctions.Queries
{
    internal class GetSuccessTransactionsQuery : IRequest<List<UserTransaction>>
    {
        public class GetSuccessTransactions : IRequestHandler<GetSuccessTransactionsQuery, List<UserTransaction>>
        {
            private readonly ITransactionRepository _transactionRepository;
            public GetSuccessTransactions(ITransactionRepository transactionRepository)
            {
                _transactionRepository = transactionRepository;
            }

            async Task<List<UserTransaction>> IRequestHandler<GetSuccessTransactionsQuery, List<UserTransaction>>.Handle(GetSuccessTransactionsQuery request, CancellationToken cancellationToken)
            {
                return await _transactionRepository.getSuccessTransactions();
            }
        }
    }
}
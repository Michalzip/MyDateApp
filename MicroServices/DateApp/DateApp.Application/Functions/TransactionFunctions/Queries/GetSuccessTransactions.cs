using Domain.Interfaces.Repositories;


namespace Application.Functions.TransactionFunctions.Queries
{
    public class GetSuccessTransactionsQuery : IRequest<List<UserTransaction>>
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
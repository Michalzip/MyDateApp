

using Domain.Interfaces.Repositories;

namespace DateApp.Functions.TransactionFunctions.Queries
{
    public class GetLastTransactionQuery : IRequest<UserTransaction>
    {

        public class GetLastTransaction : IRequestHandler<GetLastTransactionQuery, UserTransaction>
        {
            private readonly ITransactionRepository _transactionRepository;
            public GetLastTransaction(ITransactionRepository transactionRepository)
            {
                _transactionRepository = transactionRepository;
            }

            async Task<UserTransaction> IRequestHandler<GetLastTransactionQuery, UserTransaction>.Handle(GetLastTransactionQuery request, CancellationToken cancellationToken)
            {
                return await _transactionRepository.GetLastTransactionById();
            }
        }
    }
}
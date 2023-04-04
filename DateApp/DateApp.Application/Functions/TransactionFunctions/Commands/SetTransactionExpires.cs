
using Domain.Interfaces.Repositories;

namespace Application.Functions.TransactionFunctions.Commands
{
    public class SetTransactionExpiresCommand : IRequest<int>
    {



        public class SetTransactionExpires : IRequestHandler<SetTransactionExpiresCommand, int>
        {
            private readonly ITransactionRepository _transactionRepository;

            public SetTransactionExpires(ITransactionRepository transactionRepository)
            {
                _transactionRepository = transactionRepository;
            }



            async Task<int> IRequestHandler<SetTransactionExpiresCommand, int>.Handle(SetTransactionExpiresCommand request, CancellationToken cancellationToken)
            {

                var transaction = await _transactionRepository.getLastTransaction();

                transaction.Expires = true;

                transaction.PendingConfirm = false;

                _transactionRepository.update(transaction);

                return _transactionRepository.saveChanges();
            }
        }

    }
}
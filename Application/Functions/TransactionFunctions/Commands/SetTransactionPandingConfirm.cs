using Domain.Interfaces.Repositories;

namespace Application.Functions.TransactionFunctions.Commands
{

    public class SetTransactionPandingConfirmCommand : IRequest<int>
    {



        public class SetTransactionExpires : IRequestHandler<SetTransactionPandingConfirmCommand, int>
        {
            private readonly ITransactionRepository _transactionRepository;

            public SetTransactionExpires(ITransactionRepository transactionRepository)
            {
                _transactionRepository = transactionRepository;
            }



            async Task<int> IRequestHandler<SetTransactionPandingConfirmCommand, int>.Handle(SetTransactionPandingConfirmCommand request, CancellationToken cancellationToken)
            {


                var transaction = await _transactionRepository.getLastTransaction();

                transaction.PendingConfirm = true;

                _transactionRepository.update(transaction);

                return _transactionRepository.saveChanges();
            }
        }

    }
}
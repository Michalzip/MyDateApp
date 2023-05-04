
namespace DateApp.Domain.Functions.TransactionFunctions.Commands
{
    public class SetTransactionSuccessCommand : IRequest<int>
    {
        public class SetTransactionExpires : IRequestHandler<SetTransactionSuccessCommand, int>
        {
            private readonly ITransactionRepository _transactionRepository;

            public SetTransactionExpires(ITransactionRepository transactionRepository)
            {
                _transactionRepository = transactionRepository;
            }

            async Task<int> IRequestHandler<SetTransactionSuccessCommand, int>.Handle(SetTransactionSuccessCommand request, CancellationToken cancellationToken)
            {
                var transaction = await _transactionRepository.getLastTransaction();

                transaction.Success = true;

                transaction.PendingConfirm = false;

                _transactionRepository.update(transaction);

                return _transactionRepository.saveChanges();
            }
        }
    }
}
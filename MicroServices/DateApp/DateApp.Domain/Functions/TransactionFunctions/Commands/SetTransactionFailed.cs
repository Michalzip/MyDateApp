namespace DateApp.Domain.Functions.TransactionFunctions.Commands
{
    public class SetTransactionFailed
    {
    }

    public class SetTransactionFailedCommand : IRequest<int>
    {
        public class SetTransactionExpires : IRequestHandler<SetTransactionFailedCommand, int>
        {
            private readonly ITransactionRepository _transactionRepository;

            public SetTransactionExpires(ITransactionRepository transactionRepository)
            {
                _transactionRepository = transactionRepository;
            }

            async Task<int> IRequestHandler<SetTransactionFailedCommand, int>.Handle(SetTransactionFailedCommand request, CancellationToken cancellationToken)
            {
                var transaction = await _transactionRepository.getLastTransaction();

                transaction.Failed = true;

                transaction.PendingConfirm = false;

                _transactionRepository.update(transaction);

                return _transactionRepository.saveChanges();
            }
        }
    }
}
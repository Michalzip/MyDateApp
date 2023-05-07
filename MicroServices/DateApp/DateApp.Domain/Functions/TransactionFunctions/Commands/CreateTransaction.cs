namespace DateApp.Domain.Functions.TransactionFunctions.Commands
{
    internal class CreateTransactionCommand : IRequest<int>
    {
        public UserTransaction? UserTransaction { get; set; }

        public class CreateTransaction : IRequestHandler<CreateTransactionCommand, int>
        {
            private readonly ITransactionRepository _transactionRepository;

            public CreateTransaction(ITransactionRepository transactionRepository)
            {
                _transactionRepository = transactionRepository;
            }

            async Task<int> IRequestHandler<CreateTransactionCommand, int>.Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
            {
                request.UserTransaction.PendingConfirm = true;

                _transactionRepository.add(request.UserTransaction);

                return _transactionRepository.saveChanges();
            }
        }
    }
}
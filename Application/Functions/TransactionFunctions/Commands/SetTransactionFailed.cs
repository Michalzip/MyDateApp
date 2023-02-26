using Domain.Interfaces.Repositories;

namespace DateApp.Functions.TransactionFunctions.Commands
{
    public class SetTransactionFailed
    {

    }

    public class SetTransactionFailedCommand : IRequest<int>
    {

        public UserTransaction? UserTransaction { get; set; }

        public class SetTransactionExpires : IRequestHandler<SetTransactionFailedCommand, int>
        {
            private readonly ITransactionRepository _transactionRepository;

            public SetTransactionExpires(ITransactionRepository transactionRepository)
            {
                _transactionRepository = transactionRepository;
            }



            async Task<int> IRequestHandler<SetTransactionFailedCommand, int>.Handle(SetTransactionFailedCommand request, CancellationToken cancellationToken)
            {

                request.UserTransaction.Failed = true;
                request.UserTransaction.PendingConfirm = false;

                _transactionRepository.Update(request.UserTransaction);
                return _transactionRepository.SaveChanges();
            }
        }

    }
}
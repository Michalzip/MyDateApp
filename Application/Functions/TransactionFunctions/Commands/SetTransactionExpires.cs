
using Domain.Interfaces.Repositories;

namespace DateApp.Functions.TransactionFunctions.Commands
{
    public class SetTransactionExpiresCommand : IRequest<int>
    {

        public UserTransaction? UserTransaction { get; set; }

        public class SetTransactionExpires : IRequestHandler<SetTransactionExpiresCommand, int>
        {
            private readonly ITransactionRepository _transactionRepository;

            public SetTransactionExpires(ITransactionRepository transactionRepository)
            {
                _transactionRepository = transactionRepository;
            }



            async Task<int> IRequestHandler<SetTransactionExpiresCommand, int>.Handle(SetTransactionExpiresCommand request, CancellationToken cancellationToken)
            {

                request.UserTransaction.Expires = true;

                request.UserTransaction.PendingConfirm = false;

                _transactionRepository.Update(request.UserTransaction);

                return _transactionRepository.SaveChanges();
            }
        }

    }
}
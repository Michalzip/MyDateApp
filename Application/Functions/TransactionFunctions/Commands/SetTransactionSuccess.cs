using Domain.Interfaces.Repositories;

namespace DateApp.Functions.TransactionFunctions.Commands
{


    public class SetTransactionSuccessCommand : IRequest<int>
    {

        public UserTransaction? UserTransaction { get; set; }

        public class SetTransactionExpires : IRequestHandler<SetTransactionSuccessCommand, int>
        {
            private readonly ITransactionRepository _transactionRepository;

            public SetTransactionExpires(ITransactionRepository transactionRepository)
            {
                _transactionRepository = transactionRepository;
            }



            async Task<int> IRequestHandler<SetTransactionSuccessCommand, int>.Handle(SetTransactionSuccessCommand request, CancellationToken cancellationToken)
            {

                request.UserTransaction.Success = true;

                request.UserTransaction.PendingConfirm = false;

                _transactionRepository.Update(request.UserTransaction);

                return _transactionRepository.SaveChanges();
            }
        }

    }
}

using Domain.Interfaces.Repositories;

namespace DateApp.Functions.TransactionFunctions.Commands
{
    public class CreateTransactionCommand : IRequest<int>
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

                _transactionRepository.Add(request.UserTransaction);

                return _transactionRepository.SaveChanges();
            }
        }

    }
}
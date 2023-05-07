
using DateApp.Domain.Functions.TransactionFunctions.Queries;
using DateApp.Domain.Functions.TransactionFunctions.Commands;
using DateApp.Domain.Interfaces.Messages;

namespace DateApp.Domain.Services
{
    internal class TransactionService : ITransactionService
    {
        private readonly IMediator _mediator;
        private readonly IPaypalService _paypalRepository;

        private readonly IRpcClient _rpcClient;
        public TransactionService(IMediator mediator, IPaypalService paypalRepository, IRpcClient rpcClient)
        {
            _rpcClient = rpcClient;
            _mediator = mediator;
            _paypalRepository = paypalRepository;
        }

        public async Task<int> UpdatePreviousTransaction()
        {
            var previousTransaction = await _mediator.Send(new GetLastTransactionQuery { });

            if (previousTransaction == null && previousTransaction.PendingConfirm == false) throw new FailedOperationException("Failed to update status transaction");

            return await _mediator.Send(new SetTransactionExpiresCommand { });
        }

        public async Task<string> CreateTransaction(string? username)
        {
            var payment = _paypalRepository.CreatePayment();

            var user = await _mediator.Send(new GetUserByNameQuery { UserName = username });

            if (user == null) throw new NotFoundException("not user found");

            var transaction = new UserTransaction
            {
                Amount = payment.transactions[0].item_list.items[0].quantity,
                TransactionId = payment.id,
                Currency = payment.transactions[0].amount.currency,
                ByUser = user
            };

            var result = await _mediator.Send(new CreateTransactionCommand { UserTransaction = transaction });

            if (result == 0) throw new FailedOperationException("Failed to create transaction");

            return _paypalRepository.GetPaymentLink(payment);
        }

        public async Task<List<UserTransaction>> GetSuccessTransactions()
        {
            return await _mediator.Send(new GetSuccessTransactionsQuery { });
        }

        public async Task ConfirmTransaction(string? payerID, string? guid, string? username)
        {
            var vipStatus = await _rpcClient.VipStatusPublisher(username);

            if (vipStatus) throw new AlreadyExistsException("vip already exists");

            var resultSetFailed = await _mediator.Send(new SetTransactionFailedCommand());

            if (resultSetFailed == 0) throw new FailedOperationException("status transaction not been changed");

            var paymentConfirm = _paypalRepository.ConfirmPayment(payerID, guid);

            if (paymentConfirm == null)
            {
                await _mediator.Send(new SetTransactionExpiresCommand());

                throw new FailedOperationException("payments not execute, please try again..");
            }

            if (paymentConfirm.state.ToLower() != "approved")
            {
                await _mediator.Send(new SetTransactionFailedCommand());

                throw new FailedOperationException("payment not approved");
            }

            var createVipSuccessful = await _rpcClient.CreateVipPublisher(username);

            if (!createVipSuccessful) throw new FailedOperationException("vip has not been created");

            var resultSetSuccess = await _mediator.Send(new SetTransactionSuccessCommand());

            if (resultSetSuccess == 0) throw new FailedOperationException("status transaction not been changed");
        }
    }
}


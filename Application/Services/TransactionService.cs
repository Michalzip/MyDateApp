
using DateApp.Functions.TransactionFunctions.Queries;
using DateApp.Functions.TransactionFunctions.Commands;
using Domain.Interfaces.Services;
using Infrastructure.Services.Interfaces;
using Server.Functions.UserFunctions.Queries;

namespace DateApp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMediator _mediator;
        private readonly IPaypalService _paypalRepository;
        private readonly IUserService _userService;
        public TransactionService(IMediator mediator, IPaypalService paypalRepository, IUserService userService)
        {

            _mediator = mediator;
            _paypalRepository = paypalRepository;
            _userService = userService;
        }

        public async Task<int> UpdatePreviousTransaction()
        {
            var getLastTransaction = new GetLastTransactionQuery { };

            var previousTransaction = await _mediator.Send(getLastTransaction);

            if (previousTransaction != null && previousTransaction.PendingConfirm == true)
            {

                var setTransactionExpires = new SetTransactionExpiresCommand
                {
                    UserTransaction = previousTransaction
                };

                return await _mediator.Send(setTransactionExpires);

            }

            return 0;

        }

        public async Task<string> CreateTransaction(string? username)
        {

            var payment = _paypalRepository.CreateVipPayment();

            var transaction = new UserTransaction
            {
                Amount = payment.transactions[0].item_list.items[0].quantity,
                TransactionId = payment.id,
                Currency = payment.transactions[0].amount.currency
            };

            var setTransactionPendingConfirm = new SetTransactionPandingConfirmCommand
            {
                UserTransaction = transaction

            };

            var result = await _mediator.Send(setTransactionPendingConfirm);

            if (result == 0) return null;

            return _paypalRepository.GetPaymentLink(payment);


        }


        public async Task<string> ConfirmTransaction(string? payerID, string? guid, string? username)
        {
            var getCurrentTransaction = new GetLastTransactionQuery { };

            var currentTransaction = await _mediator.Send(getCurrentTransaction);

            var existsVipStatusQuery = new ExistsVipStatusQuery
            {
                UserName = username
            };

            var vipUser = await _mediator.Send(existsVipStatusQuery);

            if (vipUser)
            {
                var setTransactionFailed = new SetTransactionFailedCommand
                {

                    UserTransaction = currentTransaction
                };

                await _mediator.Send(setTransactionFailed);

                return "user already has vip";

            };

            var paymentConfirm = _paypalRepository.ConfirmPayment(payerID, guid);

            if (paymentConfirm == null)
            {

                var setTransactionExpires = new SetTransactionExpiresCommand
                {
                    UserTransaction = currentTransaction
                };

                await _mediator.Send(setTransactionExpires);

                return "payments not execute, please try again..";


            }


            if (paymentConfirm.state.ToLower() != "approved")
            {
                var setTransactionFailed = new SetTransactionFailedCommand
                {

                    UserTransaction = currentTransaction
                };

                await _mediator.Send(setTransactionFailed);


                return "Payment not approved";

            }

            var createVip = await _userService.CreateVipIdentityUser(username);

            if (!createVip.Succeeded) return "Vip is not created...";

            var setTransactionSuccess = new SetTransactionSuccessCommand
            {

                UserTransaction = currentTransaction
            };

            var result = await _mediator.Send(setTransactionSuccess);

            if (result >= 0) return $" user : {username} buy vip successfuly";

            return "unhandled error";

        }

    }
}


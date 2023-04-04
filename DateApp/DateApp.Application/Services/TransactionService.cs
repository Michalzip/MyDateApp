
using Application.Functions.TransactionFunctions.Queries;
using Application.Functions.TransactionFunctions.Commands;
using Application.Interfaces.Services;
using Domain.Interfaces.ExternalApiServices;
using IdentityServer.Application.Functions.Queries;

namespace Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMediator _mediator;
        private readonly IPaypalService _paypalRepository;
        private readonly IDentityUserService _identityUserService;
        private readonly IMapper _mapper;
        public TransactionService(IMediator mediator, IPaypalService paypalRepository, IDentityUserService identityUserService, IMapper mapper)
        {

            _mediator = mediator;
            _paypalRepository = paypalRepository;
            _identityUserService = identityUserService;
            _mapper = mapper;

        }

        public async Task<int> UpdatePreviousTransaction()
        {

            var previousTransaction = await _mediator.Send(new GetLastTransactionQuery { });

            if (previousTransaction != null && previousTransaction.PendingConfirm == true)
            {

                return await _mediator.Send(new SetTransactionExpiresCommand { });

            }

            return 0;

        }

        public async Task<string> CreateTransaction(string? username)
        {

            var payment = _paypalRepository.CreatePayment();

            var transaction = new UserTransaction
            {
                Amount = payment.transactions[0].item_list.items[0].quantity,
                TransactionId = payment.id,
                Currency = payment.transactions[0].amount.currency
            };


            var result = await _mediator.Send(new CreateTransactionCommand { UserTransaction = transaction });

            if (result == 0) return null;

            return _paypalRepository.GetPaymentLink(payment);


        }

        public async Task<List<TransactionDto>> GetSuccessTransactions()
        {
            var successTransaction = await _mediator.Send(new GetSuccessTransactionsQuery { });

            return _mapper.Map<List<UserTransaction>, List<TransactionDto>>(successTransaction);
        }

        public async Task<string> ConfirmTransaction(string? payerID, string? guid, string? username)
        {

            var vipUser = await _mediator.Send(new GetVipStatusQuery { UserName = username });

            if (vipUser)
            {

                await _mediator.Send(new SetTransactionFailedCommand { });

                return "user already has vip";

            };

            var paymentConfirm = _paypalRepository.ConfirmPayment(payerID, guid);

            if (paymentConfirm == null)
            {
                await _mediator.Send(new SetTransactionExpiresCommand { });

                return "payments not execute, please try again..";


            }


            if (paymentConfirm.state.ToLower() != "approved")
            {
                await _mediator.Send(new SetTransactionFailedCommand { });

                return "Payment not approved";

            }

            var createVip = await _identityUserService.CreateVipUser(username);

            if (!createVip.Succeeded) return "Vip is not created...";

            var result = await _mediator.Send(new SetTransactionSuccessCommand { });

            if (result >= 0) return $" user : {username} buy vip successfuly";

            return "unhandled error";

        }

    }
}


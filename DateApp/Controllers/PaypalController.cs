
using Microsoft.AspNetCore.Mvc;
using DateApp.Repositories.Interfaces;
using DateApp.Extensions;
using DateApp.Entities;

namespace App.Controllers
{
    [Authorize(Policy = "UserProfile")]
    public class PaypalController : Controller
    {
        private readonly ILogger<PaypalController> _logger;
        private readonly IPaypalRepository _paypalRepository;
        private readonly IIdentityUserRepo _identityUserRepo;
        private readonly IUnitOfWork _unitOfWork;


        public PaypalController(ILogger<PaypalController> logger, IPaypalRepository paypalRepository, IIdentityUserRepo identityUserRepo, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _paypalRepository = paypalRepository;
            _identityUserRepo = identityUserRepo;
            _unitOfWork = unitOfWork;


        }

        [HttpGet("BuyVip")]
        public async Task<ActionResult> BuyVip()
        {

            var previosTransaction = _unitOfWork.TransactionRepository.GetThePreviousTransaction().Result;

            if (previosTransaction != null && previosTransaction.PendingConfirm == true)
            {
                _unitOfWork.TransactionRepository.PaymentExpires(previosTransaction);

            }

            var payment = _paypalRepository.CreateVipPayment();

            var paymentConfirmLink = _paypalRepository.GetPaymentLink(payment);


            var transaction = new UserTransaction { Amount = payment.transactions[0].item_list.items[0].quantity, TransactionId = payment.id, Currency = payment.transactions[0].amount.currency };

            _unitOfWork.TransactionRepository.PaymentPandingConfirm(transaction);

            await _unitOfWork.Complete();

            if (paymentConfirmLink != null) return Ok($"confirm your purchase in : {paymentConfirmLink}");

            return NotFound();
        }


        [HttpGet("ConfirmPayment")]
        public async Task<ActionResult> ConfirmPayment([FromQuery] string? PayerID, [FromQuery] string? guid)
        {


            string currentUser = User.GetUsername();

            var isVipUser = _identityUserRepo.CheckUserVipExists(currentUser).Result;

            if (isVipUser) return BadRequest("user already has vip");


            var paymentConfirm = _paypalRepository.ConfirmPayment(PayerID, guid);

            if (paymentConfirm == null)
            {

                var lastTransaction = _unitOfWork.TransactionRepository.GetLastTransaction().Result;

                _unitOfWork.TransactionRepository.PaymentExpires(lastTransaction);

                await _unitOfWork.Complete();

                return BadRequest("payments not execute, please try again..");

            }

            var transaction = new UserTransaction { Amount = paymentConfirm.transactions[0].item_list.items[0].quantity, TransactionId = paymentConfirm.id, Currency = paymentConfirm.transactions[0].amount.currency };

            if (paymentConfirm.state.ToLower() != "approved")
            {
                _unitOfWork.TransactionRepository.PaymentFailed(transaction);

                await _unitOfWork.Complete();

                return BadRequest("Payment not approved");
            }


            var createVip = await _identityUserRepo.SetIdentityVipUser(currentUser);

            if (!createVip.Succeeded) return BadRequest("Vip is not created...");

            _unitOfWork.TransactionRepository.PaymentSuccess(transaction);

            var complete = await _unitOfWork.Complete();

            if (complete == true) return Ok($" user : {currentUser} buy vip successfuly");

            return BadRequest("unhandled error");


        }

    }
}
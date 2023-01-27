
using Microsoft.AspNetCore.Mvc;
using DateApp.Repositories;
using Microsoft.AspNetCore.Session;
using PayPal.Api;
using Api.Extensions;
using System;
using DateApp.Repositories.Interfaces;
using DateApp.Extensions;
namespace App.Controllers
{
    [Authorize(Policy = "UserProfile")]
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IIdentityUserRepo _identityUserRepo;


        public PaymentController(ILogger<PaymentController> logger, IPaymentRepository paymentRepository, IIdentityUserRepo identityUserRepo)
        {
            _logger = logger;
            _paymentRepository = paymentRepository;
            _identityUserRepo = identityUserRepo;


        }


        [HttpGet("BuyVip")]
        public ActionResult BuyVip()
        {
            var paymentConfirmLink = _paymentRepository.BuyVip();

            if (paymentConfirmLink != null) return Ok($"confirm your purchase in : {paymentConfirmLink}");

            return NotFound();
        }


        [HttpGet("ConfirmPayment")]
        public async Task<ActionResult> ConfirmPayment([FromQuery] string? PayerID, [FromQuery] string? guid)
        {


            string currentUser = User.GetUsername();

            var isVipUser = _identityUserRepo.CheckUserVipExists(currentUser).Result;

            if (isVipUser) return BadRequest("user already has vip");

            var paymentConfirm = _paymentRepository.ConfirmPayment(PayerID, guid);

            if (paymentConfirm == false) return BadRequest("payments not execute, please try again..");

            var result = await _identityUserRepo.SetIdentityVipUser(currentUser);

            if (result.Succeeded) return Ok($" user : {currentUser} buy vip successfuly");

            return BadRequest("unhandled error");




        }

    }
}
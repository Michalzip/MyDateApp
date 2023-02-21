
using Microsoft.AspNetCore.Mvc;
using DateApp.Repositories.Interfaces;
using DateApp.Extensions;
using DateApp.Entities;

namespace App.Controllers
{
    [Authorize(Policy = "UserProfile")]
    public class TransactionController : Controller
    {

        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {

            _transactionService = transactionService;

        }

        [HttpGet("create-transaction")]
        public async Task<ActionResult> CreateTransaction()
        {

            await _transactionService.UpdatePreviousTransaction();

            string currentUser = User.GetUsername();

            var rezult = await _transactionService.CreateTransaction(currentUser);

            return Ok(rezult);

        }


        [HttpGet("confirm-transaction")]
        public async Task<ActionResult> ConfirmTransaction([FromQuery] string? payerID, [FromQuery] string? guid)
        {


            string currentUser = User.GetUsername();

            var rezult = await _transactionService.ConfirmTransaction(payerID, guid, currentUser);

            return Ok(rezult);

        }

    }
}
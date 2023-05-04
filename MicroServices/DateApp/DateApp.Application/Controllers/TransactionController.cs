
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("dateapp/[controller]")]
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

            await _transactionService.ConfirmTransaction(payerID, guid, currentUser);

            return Ok("vip succesfully bought");
        }
    }
}
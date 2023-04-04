

using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Services;

using Application.Functions.TransactionFunctions.Queries;
namespace Application.Controllers
{

    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {


        private readonly ITransactionService _transactionService;

        public AdminController(ITransactionService transactionService)
        {

            _transactionService = transactionService;

        }


        [HttpGet("get-success-transactions")]
        public async Task<ActionResult<PagedList<TransactionDto>>> GetSuccessTransactions([FromQuery] PaginationParams paginationParams)
        {

            var result = _transactionService.GetSuccessTransactions().Result;

            if (result == null) return NotFound("no transactions");

            return PagedList<TransactionDto>.ToPagedList(result,
               paginationParams.PageNumber,
               paginationParams.PageSize);

        }

    }
}


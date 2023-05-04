using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("dateapp/[controller]")]

    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;
        public AdminController(ITransactionService transactionService, IMapper mapper)
        {
            _mapper = mapper;
            _transactionService = transactionService;
        }

        [HttpGet("get-success-transactions")]
        public async Task<ActionResult<PagedList<TransactionDto>>> GetSuccessTransactions([FromQuery] PaginationParams paginationParams)
        {
            var result = await _transactionService.GetSuccessTransactions();

            if (result == null) return NotFound("no transactions");

            var successTransactionDto = _mapper.Map<List<UserTransaction>, List<TransactionDto>>(result);

            return PagedList<TransactionDto>.ToPagedList(successTransactionDto,
               paginationParams.PageNumber,
               paginationParams.PageSize);
        }
    }
}


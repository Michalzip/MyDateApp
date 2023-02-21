

using Microsoft.AspNetCore.Mvc;
using DateApp.Entities;
using DateApp.Helpers;
using DateApp.Functions.TransactionFunctions.Queries;

namespace App.Controllers
{

    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {


        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AdminController(IMapper mapper, IMediator mediator)
        {

            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpGet("get-success-transactions")]
        public async Task<ActionResult<PagedList<TransactionDto>>> GetSuccessTransactions([FromQuery] PaginationParams paginationParams)
        {

            var getSuccessTransactions= new GetSuccessTransactionsQuery{};

            var successTransaction = await _mediator.Send(getSuccessTransactions);


            if (!successTransaction.Any()) return NotFound("not found success transactions");

            var successTransactions = _mapper.Map<List<UserTransaction>, List<TransactionDto>>(successTransaction);

            return PagedList<TransactionDto>.ToPagedList(successTransactions,
               paginationParams.PageNumber,
               paginationParams.PageSize);


        }

    }
}




using Microsoft.AspNetCore.Mvc;
using DateApp.Entities;
using DateApp.Helpers;

namespace App.Controllers
{

    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet("GetSuccessTransactions")]
        public async Task<ActionResult<PagedList<TransactionDto>>> GetSuccessTransactions([FromQuery] PaginationParams paginationParams)
        {
            var successTransaction = _unitOfWork.TransactionRepository.GetSuccessTransactions().Result;

            if (!successTransaction.Any()) return NotFound();

            var successTransactions = _mapper.Map<List<UserTransaction>, List<TransactionDto>>(successTransaction);

            return PagedList<TransactionDto>.ToPagedList(successTransactions,
               paginationParams.PageNumber,
               paginationParams.PageSize);

           
        }

    }
}


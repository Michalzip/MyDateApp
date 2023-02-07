

using Microsoft.AspNetCore.Mvc;
using DateApp.Helpers;
using Api.Repository;
using App.Db;
using DateApp.Entities;
using Microsoft.EntityFrameworkCore;
using Api.Repositories.Interfaces;
using Api.DTOs;

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
        public async Task<ActionResult<UserTransaction>> GetSuccessTransactions()
        {
            var successTransaction = _unitOfWork.TransactionRepository.GetSuccessTransactions().Result;

            if (successTransaction.Any()) return Ok(_mapper.Map<List<UserTransaction>, List<TransactionDto>>(successTransaction));

            return NotFound("Not found success transactions...");
        }

    }
}


using System;
using App.Db;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
	public class AdminRepository
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AdminRepository(AppDbContext context, IUnitOfWork unitOfWork)
		{
            _context = context;
            _unitOfWork = unitOfWork;
        }



    



        
    };
}


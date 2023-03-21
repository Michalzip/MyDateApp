using Domain.Entities;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class TransactionRepository : RepositoryBase<UserTransaction>, ITransactionRepository
    {


        public TransactionRepository(AppDbContext context) : base(context)

        {

        }

        public async Task<UserTransaction> getLastTransaction()
        {
            return await _dbContext.Transactions.OrderByDescending(u => u.Id).FirstOrDefaultAsync();
        }

        public async Task<List<UserTransaction>> getSuccessTransactions()
        {
            return _dbContext.Transactions.Where(u => u.Success == true).ToList();
        }


    }
}
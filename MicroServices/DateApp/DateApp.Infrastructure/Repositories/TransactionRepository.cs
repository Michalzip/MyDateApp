using Domain.Entities;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    internal class TransactionRepository : RepositoryBase<UserTransaction>, ITransactionRepository
    {
        public TransactionRepository(CoreContext context) : base(context)
        {
        }

        public async Task<UserTransaction> getLastTransaction()
        {
            return await _dbContext.Transactions.OrderByDescending(u => u.Id).FirstOrDefaultAsync();
        }

        public async Task<List<UserTransaction>> getSuccessTransactions()
        {
            return await _dbContext.Transactions.Include(x => x.ByUser).Where(u => u.Success == true).ToListAsync();
        }
    }
}
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ITransactionRepository : IRepository<UserTransaction>
    {
        public Task<UserTransaction> getLastTransaction();
        public Task<List<UserTransaction>> getSuccessTransactions();
    }
}
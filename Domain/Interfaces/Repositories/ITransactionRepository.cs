using Api.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ITransactionRepository : IRepository<UserTransaction>
    {
        public Task<UserTransaction> GetLastTransactionById();
        public Task<List<UserTransaction>> GetSuccessTransactions();
    }
}
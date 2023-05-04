
namespace DateApp.Domain.Interfaces.Services
{
    public interface ITransactionService
    {
        public Task<int> UpdatePreviousTransaction();
        public Task<string> CreateTransaction(string? username);
        public Task ConfirmTransaction(string? payerID, string? guid, string? username);
        public Task<List<UserTransaction>> GetSuccessTransactions();

    }
}

namespace Application.Interfaces.Services
{
    public interface ITransactionService
    {
        public Task<int> UpdatePreviousTransaction();
        public Task<string> CreateTransaction(string? username);
        public Task<string> ConfirmTransaction(string? payerID, string? guid, string? username);
        public Task<List<TransactionDto>> GetSuccessTransactions();

    }
}
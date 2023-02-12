using System;
using DateApp.Entities;

namespace Api.Repositories.Interfaces
{
	public interface ITransactionRepository
	{

        void AddStatusPayment(UserTransaction transaction);
        Task<UserTransaction> GePaymentById(string transactionId);
        public void UpdateStatusPayemnt(UserTransaction transaction);
        public  Task<UserTransaction> GetLastTransaction();
        public void PaymentPandingConfirm(UserTransaction transaction);
        public void PaymentSuccess(UserTransaction transaction);
        void PaymentExpires(UserTransaction transaction);
        public void PaymentFailed(UserTransaction transaction);
        Task<UserTransaction> GetThePreviousTransaction();
        Task<List<UserTransaction>> GetSuccessTransactions();
    }
}


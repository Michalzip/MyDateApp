using System;
using App.Db;
using DateApp.Entities;
using Microsoft.EntityFrameworkCore;
using Api.Repositories.Interfaces;

namespace Api.Repositories
{
	public class TransactionRepository: ITransactionRepository
    {

        private readonly AppDbContext _context;


        public TransactionRepository(AppDbContext context)
		{
            _context = context;
        }



        public async Task<UserTransaction> GePaymentById(string transactionId)
        {

            return await _context.Transactions.Where(u => u.TransactionId == transactionId).FirstOrDefaultAsync();

        }



        public void AddStatusPayment(UserTransaction transaction)
        {

            _context.Add(transaction);
        }


        public async Task<UserTransaction> GetThePreviousTransaction()
        {

            return _context.Transactions.OrderByDescending(u => u.Id).Skip(1).FirstOrDefault();

        }

        public  async Task<UserTransaction> GetLastTransaction()
        {

          return  _context.Transactions.OrderByDescending(u => u.Id).FirstOrDefault();

        }

        public async Task<List<UserTransaction>> GetSuccessTransactions()
        {

          return   _context.Transactions.Where(u => u.Success == true).ToList();

        }

        public void UpdateStatusPayemnt(UserTransaction transaction)
        {
            _context.Update(transaction);
        }


        public void PaymentFailed(UserTransaction transaction)
        {
            transaction.Failed = true;
            transaction.PendingConfirm = false;

            _context.Update(transaction);


        }


        public void PaymentExpires(UserTransaction transaction)
        {
            transaction.Expires = true;
            transaction.PendingConfirm = false;

            _context.Update(transaction);


        }

        public void PaymentPandingConfirm(UserTransaction transaction)
        {

            transaction.PendingConfirm = true;
            _context.Update(transaction);


        }


        public void PaymentSuccess(UserTransaction transaction)
        {
            transaction.Success = true;
            transaction.PendingConfirm = false;
            

            _context.Update(transaction);


        }


    }
}


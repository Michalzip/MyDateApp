using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repositories.Interfaces;

namespace Api.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        ITransactionRepository TransactionRepository { get; }

        Task<bool> Complete();
    }
}
using Domain.Interfaces;
using System;
using Domain.Interfaces.Repositories;
using Infrastructure.Db;
namespace Infrastructure.Repositories
{
    public class RepositoryBase<T> :
  IRepository<T>
    {
        protected readonly CoreContext _dbContext;


        public RepositoryBase(CoreContext dbContext)
        {
            _dbContext = dbContext;

        }

        public void add(T entity) => _dbContext.Add(entity);
        public void update(T entity) => _dbContext.Update(entity);
        public void remove(T entity) => _dbContext.Remove(entity);
        public int saveChanges() => _dbContext.SaveChangesAsync().Result;


    }
}
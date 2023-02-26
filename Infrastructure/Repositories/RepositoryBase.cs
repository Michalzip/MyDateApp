using App.Db;
using System;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepository<T>
    {
        protected readonly AppDbContext _dbContext;

        public RepositoryBase(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity) => _dbContext.Add(entity);
        public void Update(T entity) => _dbContext.Update(entity);
        public void Remove(T entity) => _dbContext.Remove(entity);
        public int SaveChanges() => _dbContext.SaveChangesAsync().Result;


    }
}
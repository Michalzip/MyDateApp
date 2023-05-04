namespace Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        void add(T entity);
        void update(T entity);
        void remove(T entity);
        int saveChanges();

    }
}
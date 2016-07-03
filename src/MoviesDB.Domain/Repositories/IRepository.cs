namespace MoviesDB.Domain.Repositories
{
    using System.Linq;

    public interface IRepository<T, Key>
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(Key id);

        T GetById(Key id);

        IQueryable<T> GetAll();
    }
}

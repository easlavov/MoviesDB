namespace MoviesDB.Domain.Repositories
{
    using System.Collections.Generic;

    public interface IRepository<T, Key>
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(Key id);

        T GetById(Key id);

        IEnumerable<T> GetAll();
    }
}

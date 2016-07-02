namespace MoviesDB.Domain.Repositories
{
    using System.Collections.Generic;
    using MoviesDB.Domain.Models;

    public interface IRepository<T, Key> where T : BaseEntity<Key>
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T GetById(Key key);

        IEnumerable<T> GetAll();
    }
}

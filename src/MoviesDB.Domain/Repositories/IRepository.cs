namespace MoviesDB.Domain.Repositories
{
    using System.Collections.Generic;

    using MoviesDB.Domain.Models;

    public interface IRepository<T, Key> where T : BaseEntity<Key>
    {
        T Add(T entity);

        T Update(T entity);

        void Delete(Key id);

        T GetById(Key key);

        IEnumerable<T> GetAll();
    }
}

namespace MoviesDB.Domain.Repositories
{
    using System.Linq;

    /// <summary>
    ///     Exposes methods to get, set and update data in a repository.
    /// </summary>
    /// <typeparam name="T">The type of objects in the repository.</typeparam>
    /// <typeparam name="Key">The type of the repository entities primary key.</typeparam>
    public interface IRepository<T, Key>
    {
        /// <summary>
        ///     Adds a new entity in the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(T entity);

        /// <summary>
        ///     Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        ///     Removes an entity from the repository.
        /// </summary>
        /// <param name="id">The entity id.</param>
        void Delete(Key id);

        /// <summary>
        ///     Gets an entity from the repository.
        /// </summary>
        /// <param name="id">The entity id.</param>
        T GetById(Key id);

        /// <summary>
        ///     Gets all entities in the repository.
        /// </summary>
        IQueryable<T> GetAll();
    }
}

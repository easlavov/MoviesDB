namespace MoviesDB.DataAccessLayer.UnitOfWork
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IUnitOfWork
    {
        /// <summary>
        ///     Gets a set of entities from the store.
        /// </summary>
        /// <typeparam name="T">Entities type.</typeparam>
        IDbSet<T> GetSet<T>() where T : class;

        /// <summary>
        ///     Gets an entity from the store.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="entry">Entity.</param>
        DbEntityEntry<T> GetEntry<T>(T entry) where T : class;

        /// <summary>
        ///     Saves uncommitted changes.
        /// </summary>
        void SaveChanges();
    }
}

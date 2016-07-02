namespace MoviesDB.DataAccessLayer
{
    using System.Data.Entity;

    public interface IDbContext
    {
        IDbSet<T> GetSet<T>() where T : class;

        void SaveChanges();
    }
}

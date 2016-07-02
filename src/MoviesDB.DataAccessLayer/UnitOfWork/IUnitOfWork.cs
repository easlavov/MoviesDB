namespace MoviesDB.DataAccessLayer.UnitOfWork
{
    using System.Data.Entity;

    public interface IUnitOfWork
    {
        IDbSet<T> GetSet<T>() where T : class;

        void SaveChanges();
    }
}

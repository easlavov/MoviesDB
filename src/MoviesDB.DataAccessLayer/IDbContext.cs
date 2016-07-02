namespace MoviesDB.DataAccessLayer
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IDbContext
    {
        IDbSet<T> GetSet<T>() where T : class;

        DbEntityEntry<T> GetEntry<T>(T entry) where T : class;

        void SaveChanges();
    }
}

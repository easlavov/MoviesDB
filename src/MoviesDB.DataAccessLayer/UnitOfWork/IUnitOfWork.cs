namespace MoviesDB.DataAccessLayer.UnitOfWork
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IUnitOfWork
    {
        IDbSet<T> GetSet<T>() where T : class;

        DbEntityEntry<T> GetEntry<T>(T entry) where T : class;

        void SaveChanges();
    }
}

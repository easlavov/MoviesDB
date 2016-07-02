namespace MoviesDB.DataAccessLayer
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Domain.Models;

    public class MoviesDbContext : DbContext, IDbContext
    {
        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<T> GetSet<T>() where T : class
        {
            return base.Set<T>();
        }

        public DbEntityEntry<T> GetEntry<T>(T entry) where T : class
        {
            return base.Entry<T>(entry);
        }

        void IDbContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}

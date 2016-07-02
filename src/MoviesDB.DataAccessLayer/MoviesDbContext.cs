namespace MoviesDB.DataAccessLayer
{
    using System.Data.Entity;
    using MoviesDB.DataAccessLayer.Entities;

    public class MoviesDbContext : DbContext, IDbContext
    {
        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<T> GetSet<T>() where T : class
        {
            return base.Set<T>();
        }

        void IDbContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}

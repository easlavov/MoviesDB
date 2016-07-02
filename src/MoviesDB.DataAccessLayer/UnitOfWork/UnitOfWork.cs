namespace MoviesDB.DataAccessLayer.UnitOfWork
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext context;

        public UnitOfWork(IDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "Context cannot be null!");
            }

            this.context = context;
        }

        public IDbSet<T> GetSet<T>() where T : class
        {
            return this.context.GetSet<T>();
        }

        public DbEntityEntry<T> GetEntry<T>(T entry) where T : class
        {
            return context.GetEntry<T>(entry);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}

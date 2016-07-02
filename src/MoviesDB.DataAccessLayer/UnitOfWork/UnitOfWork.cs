using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDB.DataAccessLayer.UnitOfWork
{
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

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}

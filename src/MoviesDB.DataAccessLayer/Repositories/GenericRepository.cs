namespace MoviesDB.DataAccessLayer.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using MoviesDB.DataAccessLayer.UnitOfWork;
    using MoviesDB.Domain.Repositories;

    public class GenericRepository<TEntity, Key> : IRepository<TEntity, Key> where TEntity : class
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IDbSet<TEntity> dbSet;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork), "Unit of work cannot be null!");
            }

            this.unitOfWork = unitOfWork;
            this.dbSet = this.unitOfWork.GetSet<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
            this.unitOfWork.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            this.unitOfWork.GetEntry<TEntity>(entity).State = EntityState.Modified;
            this.unitOfWork.SaveChanges();
        }

        public void Delete(Key id)
        {
            var toDelete = this.dbSet.Find(id);
            this.dbSet.Remove(toDelete);
            this.unitOfWork.SaveChanges();
        }

        public TEntity GetById(Key key)
        {
            return this.dbSet.Find(key);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.dbSet;
        }
    }
}

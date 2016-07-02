namespace MoviesDB.DataAccessLayer.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using MoviesDB.DataAccessLayer.UnitOfWork;
    using MoviesDB.Domain.Repositories;

    public abstract class GenericRepository<TDataEntity, TDomainModel, Key> : IRepository<TDomainModel, Key> where TDataEntity: class
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IDbSet<TDataEntity> dbSet;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork", "Unit of work cannot be null!");
            }

            this.unitOfWork = unitOfWork;
            this.dbSet = this.unitOfWork.GetSet<TDataEntity>();
        }

        public abstract void Add(TDomainModel entity);

        public abstract void Update(TDomainModel entity);

        public void Delete(Key id)
        {
            var toDelete = this.dbSet.Find(id);
            this.dbSet.Remove(toDelete);
        }

        public abstract TDomainModel GetById(Key key);

        public abstract IEnumerable<TDomainModel> GetAll();
    }
}

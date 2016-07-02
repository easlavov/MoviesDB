namespace MoviesDB.DataAccessLayer.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MoviesDB.DataAccessLayer.Mappings;
    using MoviesDB.DataAccessLayer.UnitOfWork;

    public class MoviesRepository : GenericRepository<Entities.Movie, MoviesDB.Domain.Models.Movie, int>
    {
        public MoviesRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }

        public override void Add(Domain.Models.Movie entity)
        {
            var dataModel = MovieMapper.FromDomainModel(entity);
            this.dbSet.Add(dataModel);
        }

        public override IEnumerable<Domain.Models.Movie> GetAll()
        {
            return this.dbSet.Select(MovieMapper.FromData);
        }

        public override Domain.Models.Movie GetById(int key)
        {
            return this.dbSet.Select(MovieMapper.FromData).FirstOrDefault(x => x.Id == key);
        }

        public override void Update(Domain.Models.Movie entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Entity cannot be null!");
            }

            var entityToUpdate = this.dbSet.Find(entity.Id);
            if (entityToUpdate == null)
            {
                throw new KeyNotFoundException("No entity with key {0} found. Update failed!");
            }

            entityToUpdate.Title = entity.Title;
            entityToUpdate.Director = entity.Director;
            entityToUpdate.ReleaseDate = entity.ReleaseDate;
        }
    }
}

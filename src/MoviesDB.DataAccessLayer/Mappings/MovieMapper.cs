namespace MoviesDB.DataAccessLayer.Mappings
{
    using System;
    using System.Linq.Expressions;

    internal static class MovieMapper
    {
        public static Expression<Func<MoviesDB.Domain.Models.Movie, MoviesDB.DataAccessLayer.Entities.Movie>> FromDomain
            = ((MoviesDB.Domain.Models.Movie domainModel) =>
            new Entities.Movie
            {
                Id = domainModel.Id,
                Title = domainModel.Title,
                Director = domainModel.Director,
                ReleaseDate = domainModel.ReleaseDate
            });

        public static Expression<Func<MoviesDB.DataAccessLayer.Entities.Movie, MoviesDB.Domain.Models.Movie>> FromData
            = ((MoviesDB.DataAccessLayer.Entities.Movie domainModel) =>
            new MoviesDB.Domain.Models.Movie(domainModel.Title)
            {
                Id = domainModel.Id,
                Director = domainModel.Director,
                ReleaseDate = domainModel.ReleaseDate
            });

        public static MoviesDB.DataAccessLayer.Entities.Movie FromDomainModel(MoviesDB.Domain.Models.Movie domainModel)
        {
            return new Entities.Movie
            {
                Id = domainModel.Id,
                Title = domainModel.Title,
                Director = domainModel.Director,
                ReleaseDate = domainModel.ReleaseDate
            };
        }
    }
}

namespace MoviesDB.Domain.Services
{
    using System;
    using System.Linq;

    using MoviesDB.Domain.Models;

    /// <summary>
    ///     Exposes methods to interact with movies.
    /// </summary>
    public interface IMoviesService
    {
        /// <summary>
        ///     Adds a movie.
        /// </summary>
        /// <param name="title">The movie title. Required.</param>
        /// <param name="director">The director name. Can be empty.</param>
        /// <param name="releaseDate">The release date. Can be empty.</param>
        void Add(string title, string director, DateTime? releaseDate);
        
        /// <summary>
        ///     Updates movie data.
        /// </summary>
        /// <param name="movie">The movie to update.</param>
        void Update(Movie movie);

        /// <summary>
        ///     Gets a movie by its Id.
        /// </summary>
        /// <param name="id">The movie id.</param>
        Movie GetById(int id);

        /// <summary>
        ///     Returns all movies.
        /// </summary>
        IQueryable<Movie> All();
    }
}

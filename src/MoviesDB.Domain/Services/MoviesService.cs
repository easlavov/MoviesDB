namespace MoviesDB.Domain.Services
{
    using System;
    using MoviesDB.Domain.Models;
    using MoviesDB.Domain.Repositories;
    using Newtonsoft.Json;

    public class MoviesService : IMoviesService
    {
        private readonly IRepository<Movie, int> moviesRepository;

        /// <summary>
        ///     Creates a new instance of the <see cref="MoviesService"/> class.
        /// </summary>
        /// <param name="moviesRepository">A movies repository.</param>
        public MoviesService(IRepository<Movie, int> moviesRepository)
        {
            if (moviesRepository == null)
            {
                throw new ArgumentNullException("moviesStore");
            }

            this.moviesRepository = moviesRepository;
        }

        public Movie Add(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException("movie", "Movie cannot be null!");
            }

            return this.moviesRepository.Add(movie);
        }

        public Movie Update(Movie movie)
        {
            return this.moviesRepository.Update(movie);
        }

        public Movie GetById(int id)
        {
            return this.moviesRepository.GetById(id);
        }

        public string ExportMoviesAsJson()
        {
            var movies = this.moviesRepository.GetAll();
            var json = JsonConvert.SerializeObject(movies);
            return json;
        }
    }
}

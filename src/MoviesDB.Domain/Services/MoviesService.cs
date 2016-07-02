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
                throw new ArgumentNullException("moviesRepository");
            }

            this.moviesRepository = moviesRepository;
        }

        public void Add(string title, string director, DateTime? releaseDate)
        {
            var newMovie = new Movie
            {
                Title = title,
                Director = director,
                ReleaseDate = releaseDate
            };

            this.moviesRepository.Add(newMovie);
        }

        public void Update(Movie movie)
        {
            this.moviesRepository.Update(movie);
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

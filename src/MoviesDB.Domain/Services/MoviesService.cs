using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDB.Domain.Models;
using MoviesDB.Domain.Repositories;
using Newtonsoft.Json;

namespace MoviesDB.Domain.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IRepository<Movie, int> moviesStore;

        public MoviesService(IRepository<Movie, int> moviesStore)
        {
            if (moviesStore == null)
            {
                throw new ArgumentNullException("moviesStore");
            }

            this.moviesStore = moviesStore;
        }

        public void Add(Movie movie)
        {
            this.moviesStore.Add(movie);
        }

        public void Update(Movie movie)
        {
            this.moviesStore.Update(movie);
        }

        public Movie GetById(int id)
        {
            return this.moviesStore.GetById(id);
        }

        public string ExportMoviesAsJson()
        {
            var movies = this.moviesStore.GetAll();
            var json = JsonConvert.SerializeObject(movies);
            return json;
        }
    }
}

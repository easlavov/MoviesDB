namespace MoviesDB.Domain.Services
{
    using System;
    using System.Collections.Generic;

    using MoviesDB.Domain.Models;

    public interface IMoviesService
    {
        void Add(string title, string director, DateTime? releaseDate);
        
        void Update(Movie movie);

        Movie GetById(int id);

        IEnumerable<Movie> All();
    }
}

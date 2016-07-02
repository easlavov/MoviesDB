namespace MoviesDB.Domain.Services
{
    using System;
    using MoviesDB.Domain.Models;

    public interface IMoviesService
    {
        void Add(string title, string director, DateTime? releaseDate);
        
        void Update(Movie movie);

        Movie GetById(int id);

        string ExportMoviesAsJson();
    }
}

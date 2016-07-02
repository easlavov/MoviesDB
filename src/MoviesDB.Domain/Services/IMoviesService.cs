using MoviesDB.Domain.Models;

namespace MoviesDB.Domain.Services
{
    public interface IMoviesService
    {
        Movie Add(Movie movie);
        
        Movie Update(Movie movie);

        Movie GetById(int id);

        string ExportMoviesAsJson();
    }
}

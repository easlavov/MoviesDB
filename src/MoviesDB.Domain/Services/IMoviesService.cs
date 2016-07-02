using MoviesDB.Domain.Models;

namespace MoviesDB.Domain.Services
{
    public interface IMoviesService
    {
        void Add(Movie movie);
        
        void Update(Movie movie);

        Movie GetById(int id);

        string ExportMoviesAsJson();
    }
}

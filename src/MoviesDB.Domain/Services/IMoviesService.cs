namespace MoviesDB.Domain.Services
{
    using MoviesDB.Domain.Models;

    public interface IMoviesService
    {
        void Add(Movie movie);
        
        void Update(Movie movie);

        Movie GetById(int id);

        string ExportMoviesAsJson();
    }
}

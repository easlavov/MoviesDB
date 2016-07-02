namespace MoviesDB.Domain.Services
{
    using MoviesDB.Domain.Models;

    public interface IMoviesService
    {
        Movie Add(Movie movie);
        
        Movie Update(Movie movie);

        Movie GetById(int id);

        string ExportMoviesAsJson();
    }
}

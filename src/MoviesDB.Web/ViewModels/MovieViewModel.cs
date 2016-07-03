namespace MoviesDB.Web.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Domain.Models;

    public class MovieViewModel
    {
        public static Func<Movie, MovieViewModel> FromMovie = (movie) => new MovieViewModel            
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                ReleaseDate = movie.ReleaseDate
            };

        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
}
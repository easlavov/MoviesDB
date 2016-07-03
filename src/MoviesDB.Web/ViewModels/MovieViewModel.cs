namespace MoviesDB.Web.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using Domain.Models;

    public class MovieViewModel
    {
        public static Expression<Func<Movie, MovieViewModel>> SelectFromMovie =
            (Movie movie) =>
                new MovieViewModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Director = movie.Director,
                    ReleaseDate = movie.ReleaseDate
                };
            

        public static MovieViewModel FromMovie(Movie movie)
        {
            return new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                ReleaseDate = movie.ReleaseDate
            };
        }

        public static Movie ToMovie(MovieViewModel model)
        {
            return new Movie
            {
                Id = model.Id,
                Title = model.Title,
                Director = model.Director,
                ReleaseDate = model.ReleaseDate
            };
        }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required]
        [RegularExpression(@"[^<>]*", ErrorMessage = "Html is not allowed!")]
        [MaxLength(Movie.TitleMaxLength, ErrorMessage = "Title can't be longer than {1} characters!")]
        public string Title { get; set; }

        [Display(Name = "Director")]
        [RegularExpression(@"[^<>]*", ErrorMessage = "Html is not allowed!")]
        [MaxLength(Movie.DirectorNameMaxLength, ErrorMessage = "Director can't be longer than {1} characters!")]
        public string Director { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
    }
}
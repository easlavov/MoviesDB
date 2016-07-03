namespace MoviesDB.Web.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Domain.Models;

    public class MovieViewModel
    {
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

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required]
        [MaxLength(Movie.TitleMaxLength)]
        public string Title { get; set; }

        [Display(Name = "Director")]
        [MaxLength(Movie.DirectorNameMaxLength)]
        public string Director { get; set; }

        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
    }
}
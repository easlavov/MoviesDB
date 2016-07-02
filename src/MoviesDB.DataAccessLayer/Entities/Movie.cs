namespace MoviesDB.DataAccessLayer.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Movie : BaseEntity<int>
    {
        [Required]
        [MaxLength(MoviesDB.Domain.Models.Movie.TitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(MoviesDB.Domain.Models.Movie.DirectorNameMaxLength)]
        public string Director { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}

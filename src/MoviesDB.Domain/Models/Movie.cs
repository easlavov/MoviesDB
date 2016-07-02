namespace MoviesDB.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Movie : BaseEntity<int>
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Director { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}

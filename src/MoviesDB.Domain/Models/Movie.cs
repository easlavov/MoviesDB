namespace MoviesDB.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Movie : BaseEntity<int>
    {
        public const int TitleMaxLength = 200;
        public const int DirectorNameMaxLength = 100;

        private string title;
        private string director;
        private DateTime? releaseDate;
        
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                        "title",
                        "Title is required!");
                }

                if (value.Length > 200)
                {
                    throw new ArgumentOutOfRangeException(
                        "title",
                        string.Format("Title length must be no more than {0} characters", TitleMaxLength));
                }

                this.title = value;
            }
        }

        [MaxLength(DirectorNameMaxLength)]
        public string Director
        {
            get
            {
                return this.director;
            }

            set
            {
                if (value != null && value.Length > DirectorNameMaxLength)
                {
                    throw new ArgumentOutOfRangeException(
                        "director",
                        string.Format("Title length must be no more than {0} characters", DirectorNameMaxLength));
                }

                this.director = value;
            }
        }

        public DateTime? ReleaseDate
        {
            get
            {
                return releaseDate;
            }

            set
            {
                if (value.HasValue && value.Value.Date >= DateTime.Now.Date.AddDays(1))
                {
                    throw new ArgumentOutOfRangeException(
                        "releaseDate",
                        string.Format("Release date can't be a future date!"));
                }

                this.releaseDate = value;
            }
        }
    }
}

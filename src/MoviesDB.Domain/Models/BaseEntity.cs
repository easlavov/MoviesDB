namespace MoviesDB.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseEntity<TKey>
    {
        /// <summary>
        ///     The entity primary key.
        /// </summary>
        [Key]
        public TKey Id { get; set; }
    }
}

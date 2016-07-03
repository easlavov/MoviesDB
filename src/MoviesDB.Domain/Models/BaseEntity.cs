namespace MoviesDB.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Defines base entity properties.
    /// </summary>
    /// <typeparam name="TKey">The entity primary key type.</typeparam>
    public abstract class BaseEntity<TKey>
    {
        /// <summary>
        ///     The entity primary key.
        /// </summary>
        [Key]
        public TKey Id { get; set; }
    }
}

namespace MoviesDB.Domain.Models
{
    public abstract class BaseEntity<TKey>
    {
        /// <summary>
        ///     The entity primary key.
        /// </summary>
        public TKey Id { get; set; }
    }
}

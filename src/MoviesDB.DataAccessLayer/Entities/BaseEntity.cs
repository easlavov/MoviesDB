namespace MoviesDB.DataAccessLayer.Entities
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseEntity<Key> : IEntity<Key>
    {
        [Key]
        public Key Id { get; set; }
    }
}

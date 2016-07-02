namespace MoviesDB.DataAccessLayer.Entities
{
    public interface IEntity<Key>
    {
        Key Id { get; set; }
    }
}

namespace MoviesDB.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Domain.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesDB.DataAccessLayer.MoviesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = false;
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MoviesDbContext context)
        {
            var movieSet = context.Set<Movie>();

            movieSet.AddOrUpdate(
                x => new { x.Title, x.Director }, 
                new Movie[]
                {
                    new Movie { Title = "Star Wars", Director = "George Lucas", ReleaseDate = new DateTime(1977, 05, 25) },
                    new Movie { Title = "The Matrix", Director = "Wachowski Brothers", ReleaseDate = new DateTime(1999, 09, 03) },
                    new Movie { Title = "Amadeus", Director = "Milos Forman", ReleaseDate = new DateTime(1984, 10, 31) },
                    new Movie { Title = "Warcraft", Director = string.Empty, ReleaseDate = null },
                    new Movie { Title = "The Godfather", Director = "Francis Ford Coppola", ReleaseDate = new DateTime(1972, 03, 24) },
                    new Movie { Title = "The Dark Knight", Director = "Christopher Nolan", ReleaseDate = new DateTime(2008, 07, 25) },
                });
        }
    }
}

namespace MoviesDB.Domain.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MoviesDB.Domain.Models;

    [TestClass]
    public class MovieTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_MovieLongTitle_ThrowsOutOfRangeException()
        {
            new Movie { Title = new string('a', Movie.TitleMaxLength + 1) };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_MovieLongDirectorName_ThrowsOutOfRangeException()
        {
            new Movie() { Director = new string('a', Movie.DirectorNameMaxLength + 1) };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_MovieFutureDate_ThrowsOutOfRangeException()
        {
            new Movie() { ReleaseDate = DateTime.Now.Date.AddDays(1) };
        }
    }
}

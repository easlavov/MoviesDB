namespace MoviesDB.Domain.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Moq;
    using Repositories;
    using Services;

    [TestClass]
    public class MoviesServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_PassNullMovieStore_ThrowsArgumentNullException()
        {
            new MoviesService(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_MovieNull_ThrowsArgumentNullException()
        {
            var service = this.GetService();
            service.Add(null, null, null);
        }        

        [TestMethod]
        public void Add_ValidMovie_AddsMovieCorrectly()
        {
            var service = this.GetService();
            service.Add("Movie", null, null);
            var addedMovie = service.GetById(2);
            Assert.IsNotNull(addedMovie);
            Assert.AreNotEqual(0, addedMovie.Id);
        }

        [TestMethod]
        public void GetById_NoMovieWithSuchIdInStore_ReturnsNull()
        {
            var service = this.GetService();
            var movie = service.GetById(999);
            Assert.IsNull(movie);
        }

        [TestMethod]
        public void GetById_MovieWithSuchIdIsInStore_ReturnsMovie()
        {
            var service = this.GetService();
            var movie = service.GetById(1);
            Assert.IsNotNull(movie);
        }

        [TestMethod]
        public void Update_ValidMovie_ReturnsCorrectlyUpdatedObject()
        {
            int id = 1;
            string newTitle = "Inception";

            var service = this.GetService();
            var movieToUpdate = service.GetById(id);
            movieToUpdate.Title = newTitle;
            service.Update(movieToUpdate);
            var updatedMovire = service.GetById(1);

            Assert.AreEqual(id, movieToUpdate.Id);
            Assert.AreEqual(newTitle, movieToUpdate.Title);
        }

        [TestMethod]
        public void Export_ReturnsValidExport()
        {
            var service = this.GetService();
            string moviesJson = service.ExportMoviesAsJson();
            Assert.IsNotNull(moviesJson);
        }

        private IMoviesService GetService()
        {
            var movies = new List<Movie>
            {
                new Movie() { Id = 1, Title = "Pulp Fiction", Director = "Tarantino", ReleaseDate = new DateTime(1994, 09, 10) }
            };
            int idCounter = 2;

            var repoMock = new Mock<IRepository<Movie, int>>();
            repoMock.Setup(x => x.Add(It.IsAny<Movie>()))
                .Callback((Movie m) => 
                    {
                        m.Id = idCounter;
                        idCounter++;
                        movies.Add(m);
                    });
            repoMock.Setup(x => x.Delete(It.IsAny<int>()))
                .Callback((int id) => movies.Remove(movies.FirstOrDefault(x => x.Id == id)));
            repoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns((int id) => 
                    {
                        return movies.FirstOrDefault(x => x.Id == id);
                    });
            repoMock.Setup(x => x.Update(It.IsAny<Movie>()))
                .Callback((Movie m) =>
                {
                    var movieToUpdate = movies.FirstOrDefault(x => x.Id == m.Id);
                    movieToUpdate = m;
                });
            repoMock.Setup(x => x.GetAll())
                .Returns(() => { return movies.AsEnumerable(); });
            return new MoviesService(repoMock.Object);
        }
    }
}

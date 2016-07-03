using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GridMVCAjaxDemo.Helpers;
using MoviesDB.Domain.Models;
using MoviesDB.Domain.Services;
using MoviesDB.Web.ViewModels;

namespace MoviesDB.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string GRID_PARTIAL_PATH = "~/Views/Home/_MoviesGrid.cshtml";

        private readonly IMoviesService moviesService;
        private readonly IGridMvcHelper gridMvcHelper;

        public HomeController(IMoviesService moviesService, IGridMvcHelper gridMvcHelper)
        {
            if (moviesService == null)
            {
                throw new ArgumentNullException("moviesService");
            }

            if (gridMvcHelper == null)
            {
                throw new ArgumentNullException("gridMvcHelper");
            }

            this.moviesService = moviesService;
            this.gridMvcHelper = gridMvcHelper;
        }

        public ActionResult Index()
        {

            this.moviesService.All();
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetGrid()
        {
            var items = GetMoviesAsMovieViewModels().AsQueryable().OrderBy(x => x.Id);
            var grid = this.gridMvcHelper.GetAjaxGrid(items);
            return PartialView(GRID_PARTIAL_PATH, grid);
        }

        [HttpGet]
        public ActionResult GridPager(int? page)
        {
            var items = this.GetMoviesAsMovieViewModels().AsQueryable().OrderBy(x => x.Id);
            var grid = this.gridMvcHelper.GetAjaxGrid(items, page);
            object jsonData = this.gridMvcHelper.GetGridJsonData(grid, GRID_PARTIAL_PATH, this);
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<MovieViewModel> GetMoviesAsMovieViewModels()
        {
            return this.moviesService.All().Select(movie => new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                ReleaseDate = movie.ReleaseDate
            });
        }
    }
}
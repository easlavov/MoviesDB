namespace MoviesDB.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Domain.Models;
    using GridMVCAjaxDemo.Helpers;
    using MoviesDB.Domain.Services;
    using MoviesDB.Web.ViewModels;

    public class HomeController : Controller
    {
        private const string GRID_PARTIAL_PATH = "~/Views/Home/_MoviesGrid.cshtml";
        private const string DETAILS_PARTIAL_PATH = "~/Views/Home/_View.cshtml";
        private const string CREATE_PARTIAL_PATH = "~/Views/Home/_Add.cshtml";
        private const string EDIT_PARTIAL_PATH = "~/Views/Home/_Edit.cshtml";

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

        [HttpGet]
        public PartialViewResult Details(int id)
        {
            var moview = this.moviesService.GetById(id);
            var viewModel = MovieViewModel.FromMovie(moview);
            return this.PartialView(DETAILS_PARTIAL_PATH, viewModel);
        }

        [HttpGet]
        public PartialViewResult Create()
        {
            return this.PartialView(CREATE_PARTIAL_PATH, new MovieViewModel());
        }

        [HttpPost]
        public ActionResult Create(MovieViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.PartialView(CREATE_PARTIAL_PATH, model);
            }

            this.moviesService.Add(model.Title, model.Director, model.ReleaseDate);
            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }

        [HttpGet]
        public PartialViewResult Edit(int id)
        {
            var movie = this.moviesService.GetById(id);
            var model = MovieViewModel.FromMovie(movie);
            return this.PartialView(EDIT_PARTIAL_PATH, model);
        }

        [HttpPost]
        public ActionResult Edit(MovieViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.PartialView(EDIT_PARTIAL_PATH, model);
            }

            var movie = new Movie
            {
                Id = model.Id,
                Title = model.Title,
                Director = model.Director,
                ReleaseDate = model.ReleaseDate
            };

            this.moviesService.Update(movie);
            return new HttpStatusCodeResult(HttpStatusCode.Accepted);
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
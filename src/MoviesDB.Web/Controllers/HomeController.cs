using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviesDB.Domain.Services;

namespace MoviesDB.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMoviesService moviesService;

        public HomeController(IMoviesService moviesService)
        {
            if (moviesService == null)
            {
                throw new ArgumentNullException("moviesService");
            }

            this.moviesService = moviesService;
        }

        public ActionResult Index()
        { 
            return View();
        }
    }
}
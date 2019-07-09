using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoProject.Models;
using VideoProject.ViewModels;
using System.Data.Entity;

namespace VideoProject.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(g => g.Genre).ToList();
            return View(movies);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customerList = new List<Customer>
            {
                new Customer() {Name = "Tim"},
                new Customer() {Name = "Matt"},
            };

            var randomMovie = new RandomMovieViewModel() { Movie = movie, Customers = customerList };
            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model

            return View(randomMovie);
        }

        // GET Movies/Edit/
        public ActionResult Edit(int id)
        {
            return Content($"id={id}");
        }
        // GET: Movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }

        //    if(string.IsNullOrEmpty(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content($"pageindex={pageIndex} &&sortby={sortBy}");
        //}
        [Route("movies/released/{year: regex(\\d{4})}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"year={year},month={month}");
        }

        public ActionResult Details (int id)
        {
            if (id <= _context.Movies.ToList().Count)
            {
                var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(x => x.Id == id);

                return View(movie);
            }
            return HttpNotFound();
        }
    }
}
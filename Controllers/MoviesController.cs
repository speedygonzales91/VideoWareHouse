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
    [Authorize(Roles = RoleName.CanManageMovies)]
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
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
               // var movies = _context.Movies.Include(g => g.Genre).ToList();
                return View();
            }

            return View("ReadOnlyIndex");
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
       /* public ActionResult Edit(int id)
        {
            return Content($"id={id}");
        }
        */
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

        //[Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var movieViewModel = new MovieFormViewModel()
            {
                Movie = new Movie(),
                Genres = genres
            };
            return View("MovieSave", movieViewModel);
        }

        [ValidateAntiForgeryToken]
        [System.Web.Http.HttpPost]
        public ActionResult Save (Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var notValidModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieSave", notValidModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");      
        }

        public ActionResult Edit(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var editViewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieSave", editViewModel);
            }
        }
    }
}
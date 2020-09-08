using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRental.Controllers
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
        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RollName.CanManageMovies))
            {
                return View("List");
            }
            
            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if(movie == null)
            {
                return Content("No movie found with the given id");
            }
            return View(movie);
        }
        [Authorize(Roles =RollName.CanManageMovies)]
        public ActionResult Create()
        {
            var genreList = _context.genres.ToList();
            var viewModel = new MovieViewModel()
            { 
                
                genres = genreList
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel(movie) {
                   
                    genres = _context.genres.ToList()
                };

                return View("Create", viewModel);

            }
            movie.AddDate = DateTime.Now; 
            
            if (movie.Id == 0)
            {
                _context.movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.AddDate = movie.AddDate;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.movies.SingleOrDefault(c => c.Id == id);
            if(movie == null)
            {
                return Content("no movie found");
            }
            var viewModel = new MovieViewModel(movie)
            {
                
                genres = _context.genres.ToList()
            };
            return View(viewModel);

        }
        public ActionResult Delete(int id)
        {
            var movie = _context.movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return Content("No Movie Found");
            }
            _context.movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


    }
}
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

            var movies = _context.movies.Include(m => m.Genre).ToList();
            return View(movies);
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
        public ActionResult Save(Movie movie)
        {
            var temp = new Movie();
            temp.Id = movie.Id;
            temp.Name = movie.Name;
            temp.ReleaseDate = movie.ReleaseDate;
            temp.AddDate = DateTime.Now;
            temp.GenreId = movie.GenreId;
            temp.NumberInStock = movie.NumberInStock;
            if(temp.Id == 0)
            {
                _context.movies.Add(temp);
            }
            else
            {
                var movieInDb = _context.movies.Single(c => c.Id == temp.Id);
                movieInDb.Name = temp.Name;
                movieInDb.ReleaseDate = temp.ReleaseDate;
                movieInDb.NumberInStock = temp.NumberInStock;
                movieInDb.AddDate = temp.AddDate;
                movieInDb.GenreId = temp.GenreId;
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
            var viewModel = new MovieViewModel()
            {
                movie = movie,
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
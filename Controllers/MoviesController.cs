using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Linq;

namespace Vidly.Controllers
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

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(e => e.Genre).ToList();

            return View(movies);
        }
        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(e => e.Genre).SingleOrDefault(e => e.Id == id);

            if (movies == null) //si no existe retornar 404
                return HttpNotFound();

            return View(movies);
        }
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.SingleOrDefault(e => e.Id == id);

            if (movies == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movies,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            { 
                movie.DateAdded = DateTime.Now; //Si no entra en conflico al crear una nueva pelicula
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(e => e.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}
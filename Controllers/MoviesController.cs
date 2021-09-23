using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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
    }
}
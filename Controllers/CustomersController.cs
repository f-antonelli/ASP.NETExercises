using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
	public class CustomersController : Controller
	{
		private ApplicationDbContext _context;
		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ViewResult Index()
		{
			var movies = _context.Movies.Include(c => c.Genre).ToList();

			return View(movies);
		}

		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(e => e.MembershipType).SingleOrDefault(e => e.Id == id);

			if (customer == null) //si no existe retornar 404
				return HttpNotFound();

			return View(customer);
		}
	}
}
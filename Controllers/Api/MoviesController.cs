using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.App_Start;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
	public class MoviesController : ApiController
	{
		private readonly ApplicationDbContext _context;

		private readonly MapperConfiguration config;
		private readonly IMapper iMapper;

		public MoviesController()
		{
			_context = new ApplicationDbContext();

			config = new AutoMapperConfiguration().Configure();
			iMapper = config.CreateMapper();
		}

		//GET /api/movies
		public IEnumerable<MovieDto> GetMovies()
		{
			return _context.Movies.ToList().Select(iMapper.Map<Movie, MovieDto>);
		}
		// GET /api/movies/1
		public IHttpActionResult GetMovies(int id)
		{
			var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

			if (movie == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			return Ok(iMapper.Map<Movie, MovieDto>(movie));
		}

		//POST /api/movies
		[HttpPost]
		public IHttpActionResult CreateMovie(MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var movie = iMapper.Map<MovieDto, Movie>(movieDto);
			_context.Movies.Add(movie);
			_context.SaveChanges();

			movieDto.Id = movie.Id;
			return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
		}

		[HttpPut]
		public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var movieInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (movieInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			iMapper.Map(movieDto, movieInDb);

			_context.SaveChanges();

			return Ok();
		}

		// DELETE /api/movies/1
		[HttpDelete]
		public IHttpActionResult DeleteMovie(int id)
		{
			var movieInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (movieInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.Customers.Remove(movieInDb);
			_context.SaveChanges();

			return Ok();
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
	public class MovieFormViewModel
	{
		public IEnumerable<Genre> Genres { get; set; }
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Genre")]
		public byte GenreId { get; set; }

		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }

		[Required]
		[Display(Name = "Number in Stock")]
		[Range(1, 15)]
		public byte NumberInStock { get; set; }

		public MovieFormViewModel()
		{
			Id = 0;
		}

		public MovieFormViewModel(Movie movie)
		{
			Id = movie.Id;
			Name = movie.Name;
			GenreId = movie.GenreId;
			ReleaseDate = movie.ReleaseDate;
			NumberInStock = movie.NumberInStock;
		}
	}
}
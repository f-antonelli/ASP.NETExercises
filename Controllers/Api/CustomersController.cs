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
	public class CustomersController : ApiController
	{
		private readonly ApplicationDbContext _context;

		private readonly MapperConfiguration config;
		private readonly IMapper iMapper;

		public CustomersController()
		{
			_context = new ApplicationDbContext();

			config = new AutoMapperConfiguration().Configure();
			iMapper = config.CreateMapper();
		}

		//GET /api/customers
		public IEnumerable<CustomerDto> GetCustomers()
		{
			return _context.Customers.ToList().Select(iMapper.Map<Customer, CustomerDto>);
		}
		// GET /api/customers/1
		public IHttpActionResult GetCustomer(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			return Ok(iMapper.Map<Customer, CustomerDto>(customer));
		}

		//POST /api/customers
		[HttpPost]
		public IHttpActionResult CreateCustomer(CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var customer = iMapper.Map<CustomerDto, Customer>(customerDto);
			 _context.Customers.Add(customer);
			_context.SaveChanges();

			customerDto.Id = customer.Id;
			return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
		}

		[HttpPut]
		public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customerInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			iMapper.Map(customerDto, customerInDb);

			_context.SaveChanges();

			return Ok();
		}

		// DELETE /api/customers/1
		[HttpDelete]
		public IHttpActionResult DeleteCustomer(int id)
		{
			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customerInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.Customers.Remove(customerInDb);
			_context.SaveChanges();

			return Ok();
		}
	}
}

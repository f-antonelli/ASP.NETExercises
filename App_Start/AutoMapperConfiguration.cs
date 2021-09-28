using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.App_Start
{
	public class AutoMapperConfiguration
	{
		public MapperConfiguration Configure()
		{
			var config = new MapperConfiguration(c =>
			{
				c.AddProfile<MappingProfile>();
			});
			return config;
		}
	}
	
}
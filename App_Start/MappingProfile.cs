using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Customer Mappings
            // API -> Outbound
            CreateMap<Customer, CustomerDto>();

            // API <- Inbound : Asi le digo al automapper que no mapee el id cuando es enviado
            CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            // Movie Mappings
            // API -> Outbound
            CreateMap<Movie, MovieDto>();

            // API <- Inbound
            CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            // Membership Mappings
            // API -> Outbound
            CreateMap<MembershipType, MembershipTypeDto>();

            // Membership Mappings
            // API -> Outbound
            CreateMap<Genre, GenreDto>();
        }
    }
}
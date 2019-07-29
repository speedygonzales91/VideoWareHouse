using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoProject.DTOs;
using VideoProject.Models;

namespace VideoProject.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>()
                .ForMember(c => c.Membership, m=> m.MapFrom(k=>k.MembershipType));
            Mapper.CreateMap<CustomerDTO, Customer>();

            Mapper.CreateMap<MembershipType, MembershipDTO>();
            Mapper.CreateMap<MembershipDTO, MembershipType>();

            Mapper.CreateMap<Genre, GenreDTO>();
            Mapper.CreateMap<GenreDTO, Genre>();


            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>();

        }
    }
}
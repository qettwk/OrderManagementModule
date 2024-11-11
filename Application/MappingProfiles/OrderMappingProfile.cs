using Application.Queries.ViewModels;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            //CreateMap<Order, OrderGetToClientDTO>()
            //    .ForMember(dest => dest.AutomobilesName, opt => opt.MapFrom(src => src.));
        }
    }
}

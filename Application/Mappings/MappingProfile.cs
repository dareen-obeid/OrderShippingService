using System;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Mappings
{
	public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderShipping, OrderShippingDto>().ReverseMap();
            CreateMap<ShippingStatus, ShippingStatusDto>().ReverseMap();
        }
    }
}


﻿using AutoMapper;
using Ordering.Application.Features.Orders.Queries.GetOrders;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
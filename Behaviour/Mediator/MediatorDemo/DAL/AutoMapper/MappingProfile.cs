using AutoMapper;
using DAL.Dtos.ProductDtos;
using DAL.Dtos.ReviewDtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
      
        }
    }
}

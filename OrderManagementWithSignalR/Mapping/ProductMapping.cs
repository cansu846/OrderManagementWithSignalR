﻿using AutoMapper;
using Entities.Concrete;
using Entities.Concrete.Pages;
using SignalR.DtoLayer.ProductDto;

namespace WebApi.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, GetProductWithCategory>().ReverseMap();
        }
    }
}

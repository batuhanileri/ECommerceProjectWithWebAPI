using AutoMapper;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {          

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<User, UserForLoginDto>();
            CreateMap<UserForLoginDto, User>();

            CreateMap<User, UserForRegisterDto>();
            CreateMap<UserForRegisterDto, User>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryWithProductDto>();
            CreateMap<CategoryWithProductDto, Category>();

            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<ProductWithCategoryDto, Product>();

            
        }
    }
}

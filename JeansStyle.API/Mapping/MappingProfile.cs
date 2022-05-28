using AutoMapper;
using JeansStyle.API.Models;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ProductDto, ProductModelForMapping>().ReverseMap();
            CreateMap<CategoriesByGender, CategoriesByGenderViewModel>().ReverseMap();
            CreateMap<ProductSizeDto, ProductSize>().ReverseMap();
        }
    }
}

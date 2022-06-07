using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Mapping;
using JeansStyle.DAL.Data.Specifications;
using JeansStyle.WEB.Models;
using JeansStyle.WEB.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.WEB.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CategoriesByGender, CategoriesByGenderViewModel>().ReverseMap();
            CreateMap<ProductSizeDto, ProductSize>().ReverseMap();
            CreateMap<SizeDto, Size>().ReverseMap();
            CreateMap<GenderDto, Gender>().ReverseMap();
            CreateMap<SeasonDto, Season>().ReverseMap();

        }
    }
}

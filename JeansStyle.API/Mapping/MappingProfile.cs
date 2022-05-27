using AutoMapper;
using JeansStyle.API.Models;
using JeansStyle.BLL.DTOs;
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
           
        }
    }
}

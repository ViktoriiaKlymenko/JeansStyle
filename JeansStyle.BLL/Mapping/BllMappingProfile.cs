using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.DAL.Domain.Models;

namespace JeansStyle.BLL.Mapping
{
    public class BllMappingProfile : Profile
    {
        public BllMappingProfile()
        {
            CreateMap<ProductModelForMapping, Product>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<SizeDto, Size>().ReverseMap();
            CreateMap<ProductSizeDto, ProductSize>().ReverseMap();  
        }
    }
}

using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Models;
using JeansStyle.DAL.Data.Specifications;
using JeansStyle.DAL.Domain.Models;

namespace JeansStyle.BLL.Mapping
{
    public class BllMappingProfile : Profile
    {
        public BllMappingProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<GenderDto, Gender>().ReverseMap();
            CreateMap<SeasonDto, Season>().ReverseMap();
            CreateMap<SizeDto, Size>().ReverseMap();
            CreateMap<ProductSizeDto, ProductSize>().ReverseMap();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<CategoriesByGenderDto, CategoriesByGender>().ReverseMap();
        }
    }
}

using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.DAL.Domain.Models;

namespace JeansStyle.BLL
{
    public class BllMappingProfile : Profile
    {
        public BllMappingProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}

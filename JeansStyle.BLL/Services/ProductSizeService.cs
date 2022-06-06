using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using JeansStyle.DAL.Domain.Models;
using System;
using System.Collections.Generic;

namespace JeansStyle.BLL.Services
{
    public class ProductSizeService : IProductSizeService
    {
        private readonly IBaseRepository<ProductSize> _productSizeRepository;
        private readonly IMapper _mapper;

        public ProductSizeService(IBaseRepository<ProductSize> productSizeRepository, IMapper mapper)
        {
            _productSizeRepository = productSizeRepository;
            _mapper = mapper;   
        }

        public void AddProductSizes(ProductSizeDto productSizeDto)
        {
            var productSize = _mapper.Map<ProductSize>(productSizeDto);
            _productSizeRepository.Add(productSize);
        }


        public List<SizeDto> GetSizeByProductId(Guid productId)
        {
            var productSizes= _mapper.Map<List<ProductSizeDto>>(_productSizeRepository.FindAllWhere(s => s.ProductId== productId));
            var sizes = new List<SizeDto>();    
            foreach(var productSize in productSizes)
            {
                sizes.Add(productSize.Size);
            }

            return sizes;
        }
    }
}

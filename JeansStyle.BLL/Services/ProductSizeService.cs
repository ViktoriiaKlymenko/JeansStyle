using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using JeansStyle.DAL.Data.Specifications;
using JeansStyle.DAL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Services
{
    public class ProductSizeService : IProductSizeService
    {
        private readonly IBaseRepository<ProductSize> _productSizeRepository;
        private readonly IBaseRepository<Size> _sizeRepository;
        private readonly IMapper _mapper;

        public ProductSizeService(IBaseRepository<ProductSize> productSizeRepository, IMapper mapper, IBaseRepository<Size> sizeRepository)
        {
            _productSizeRepository = productSizeRepository;
            _mapper = mapper;
            _sizeRepository = sizeRepository;   
        }

        public void AddProductSizes(ProductSizeDto productSizeDto)
        {
            var productSize = _mapper.Map<ProductSize>(productSizeDto);
            _productSizeRepository.Add(productSize);
            _productSizeRepository.Clear();
        }


        public async Task<List<SizeDto>> GetSizeByProductId(Guid productId)
        {
            var productSizes= _mapper.Map<List<ProductSizeDto>>(await _productSizeRepository.ListAsync(new ProductSizeByProductIdSpec(productId)));
            var sizes = new List<SizeDto>();    
            foreach(var productSize in productSizes)
            {
                sizes.Add(productSize.Size);
            }
            _productSizeRepository.Clear();
        
            return sizes;
        }

        public async Task<List<ProductSizeDto>> GetProductSizeByProductId(Guid productId)
        {
            var productSizes = _mapper.Map<List<ProductSizeDto>>(await _productSizeRepository.ListAsync(new ProductSizeByProductIdSpec(productId)));
            var sizes = new List<SizeDto>();
            foreach (var productSize in productSizes)
            {
                sizes.Add(productSize.Size);
            }
            _productSizeRepository.Clear();

            return productSizes;
        }

        public async Task<ProductSizeDto> GetProductSizeByProductIdAndSizeId(Guid productId, Guid sizeId)
        {
            var productSizes = _mapper.Map<ProductSizeDto>( await _productSizeRepository.GetBySpecAsync(new ProductSizeByProductIdAndSizeId(productId, sizeId)));


            _productSizeRepository.Clear();

            return productSizes;
        }

        public async Task<string> GetNameById(Guid id)
        {
            var size = await _sizeRepository.GetBySpecAsync(new GetSizeNameById(id));
            return size.Name;
        }
    }
}

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
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IBaseRepository<Size> _sizeRepository;
        private readonly IMapper _mapper;

        public ProductSizeService(IBaseRepository<ProductSize> productSizeRepository, IMapper mapper, IBaseRepository<Size> sizeRepository, IBaseRepository<Product> productRepository)
        {
            _productSizeRepository = productSizeRepository;
            _mapper = mapper;
            _sizeRepository = sizeRepository;
            _productRepository = productRepository;
        }

        public void AddProductSizes(ProductSizeDto productSizeDto)
        {
            var productSize = _mapper.Map<ProductSize>(productSizeDto);
            _productSizeRepository.Add(productSize);
            _productSizeRepository.Clear();
        }

        public async Task<ProductSizeDto> GetProductSizeById(Guid id)
        {
            var productSizeDto = _mapper.Map<ProductSizeDto>(await _productSizeRepository.GetBySpecAsync(new ProductSizeByIdSpec(id)));
            productSizeDto.Product = _mapper.Map<ProductDto>(await _productRepository.GetBySpecAsync(new ProductByIdSpec(productSizeDto.Product.Id)));
            productSizeDto.Size = _mapper.Map<SizeDto>(await _sizeRepository.GetBySpecAsync(new SizeByIdSpec(productSizeDto.Size.Id)));
            return productSizeDto;
        }

        public async Task<List<SizeDto>> GetSizeByProductId(Guid productId)
        {
            var productSizes = _mapper.Map<List<ProductSizeDto>>(await _productSizeRepository.ListAsync(new ProductSizeByProductIdSpec(productId)));
            var sizes = new List<SizeDto>();
            foreach (var productSize in productSizes)
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
            var productSizes = _mapper.Map<ProductSizeDto>(await _productSizeRepository.GetBySpecAsync(new ProductSizeByProductIdAndSizeId(productId, sizeId)));


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

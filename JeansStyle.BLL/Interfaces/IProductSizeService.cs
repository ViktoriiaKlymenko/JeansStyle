using JeansStyle.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Interfaces
{
    public interface IProductSizeService
    {
        void AddProductSizes(ProductSizeDto productSizeDto);
        Task<List<SizeDto>> GetSizeByProductId(Guid productId);
        Task<ProductSizeDto> GetProductSizeByProductIdAndSizeId(Guid productId, Guid sizeId);
        Task<List<ProductSizeDto>> GetProductSizeByProductId(Guid productId);
        Task<string> GetNameById(Guid id);
        Task<ProductSizeDto> GetProductSizeById(Guid id);
    }
}
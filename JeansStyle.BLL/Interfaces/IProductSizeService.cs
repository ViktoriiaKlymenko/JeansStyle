using JeansStyle.BLL.DTOs;
using System;
using System.Collections.Generic;

namespace JeansStyle.BLL.Interfaces
{
    public interface IProductSizeService
    {
        void AddProductSizes(ProductSizeDto productSizeDto);
        List<SizeDto> GetSizeByProductId(Guid productId)
    }
}
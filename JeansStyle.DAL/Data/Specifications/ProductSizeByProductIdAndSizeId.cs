using Ardalis.Specification;
using JeansStyle.DAL.Domain.Models;
using System;

namespace JeansStyle.DAL.Data.Specifications
{
    public class ProductSizeByProductIdAndSizeId : Specification<ProductSize>
    {
        public ProductSizeByProductIdAndSizeId(Guid productId, Guid sizeId)
        {
            if (!(productId == Guid.Empty && sizeId == Guid.Empty))
                Query.Where(ps => ps.Product.Id == productId && ps.Size.Id == sizeId);
        }
    }
}

using Ardalis.Specification;
using JeansStyle.DAL.Domain.Models;
using System;

namespace JeansStyle.DAL.Data.Specifications
{
    public class ProductSizeByProductIdSpec
    : Specification<ProductSize>
    {
        public ProductSizeByProductIdSpec(Guid productId)
        {
            if (!(productId == Guid.Empty))
                Query.Where(ps => ps.Product.Id == productId);
        }
    }
}

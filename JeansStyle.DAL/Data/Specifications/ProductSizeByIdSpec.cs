using Ardalis.Specification;
using JeansStyle.DAL.Domain.Models;
using System;

namespace JeansStyle.DAL.Data.Specifications
{
    public class ProductSizeByIdSpec
         : Specification<ProductSize>
    {
        public ProductSizeByIdSpec(Guid id)
        {
            if (!(id == Guid.Empty))
                Query.Where(p => p.Id == id);
        }

    }
}
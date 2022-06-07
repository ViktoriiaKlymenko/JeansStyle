using Ardalis.Specification;
using JeansStyle.DAL.Domain.Models;
using System;

namespace JeansStyle.DAL.Data.Specifications
{
    public class ProductByIdSpec
      : Specification<Product>
    {
        public ProductByIdSpec(Guid id)
        {
            if (!(id == Guid.Empty))
                Query.Where(p => p.Id == id);
        }

    }
}
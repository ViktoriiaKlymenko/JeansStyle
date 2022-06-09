using Ardalis.Specification;
using JeansStyle.DAL.Domain.Models;
using System;
using System.Linq;

namespace JeansStyle.DAL.Data.Specifications
{
    public class GetOrderByIdSpec : Specification<Order>
    {
        public GetOrderByIdSpec(Guid id)
        {
            if (!(id == Guid.Empty))
                Query.Where(o => o.ProductSizes.Any(p=>p.ProductId==id));
        }
    }
}
using Ardalis.Specification;
using JeansStyle.DAL.Domain.Models;
using System;

namespace JeansStyle.DAL.Data.Specifications
{
    public class CategoryByIdSpec
    : Specification<Category>
    {
        public CategoryByIdSpec(Guid id)
        {
            if (!(id == Guid.Empty))
                Query.Where(c => c.Id == id);
        }

    }
}

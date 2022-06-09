using Ardalis.Specification;
using JeansStyle.DAL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JeansStyle.DAL.Data.Specifications
{
    public class CategoriesByGenderIdSpec
     : Specification<Category>
    {
        public CategoriesByGenderIdSpec(Guid id)
        {
            Query.Where(c => c.Products.Count>0 && c.Products.Any(p => p.Gender.Id == id));
        }

    }
}

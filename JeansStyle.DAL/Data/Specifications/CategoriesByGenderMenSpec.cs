using Ardalis.Specification;
using JeansStyle.DAL.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace JeansStyle.DAL.Data.Specifications
{
    public class CategoriesByGenderMenSpec
     : Specification<Category>
    {
        public CategoriesByGenderMenSpec()
        {
            Query.Where(c => c.Products.Any(p => p.Gender.Name == "Men"));
        }

    }
}

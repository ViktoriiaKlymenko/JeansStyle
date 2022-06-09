using Ardalis.Specification;
using JeansStyle.DAL.Domain.Models;
using System.Linq;

namespace JeansStyle.DAL.Data.Specifications
{
    public class CategoriesByGenderWomenSpec
     : Specification<Category>
    {
        public CategoriesByGenderWomenSpec()
        {
            Query.Where(c => c.Products.Any(p => p.Gender.Name == "Men"));
        }

    }
}

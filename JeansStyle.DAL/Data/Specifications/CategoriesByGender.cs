using JeansStyle.DAL.Domain.Models;
using System.Collections.Generic;

namespace JeansStyle.DAL.Data.Specifications
{
    public class CategoriesByGender
    {
        public List<Category> Men { get; set; }
        public List<Category> Women { get; set; }
    }
}

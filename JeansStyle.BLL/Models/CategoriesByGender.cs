using JeansStyle.DAL.Domain.Models;
using System.Collections.Generic;

namespace JeansStyle.BLL.Models
{
    public class CategoriesByGender
    {
        public List<Category> Men { get; set; }
        public List<Category> Women { get; set; }
    }
}

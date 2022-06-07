using JeansStyle.BLL.DTOs;
using System.Collections.Generic;

namespace JeansStyle.BLL.Models
{
    public class CategoriesByGenderDto
    {
        public List<CategoryDto> Men { get; set; }
        public List<CategoryDto> Women { get; set; }
    }
}

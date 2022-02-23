using JeansStyle.BLL.DTOs.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JeansStyle.BLL.DTOs
{
    public class ProductDto
    {
        [StringLength(15)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<Season> Season { get; set; }
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public Size Size { get; set; }
    }
}
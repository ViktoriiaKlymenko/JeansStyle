using JeansStyle.API.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JeansStyle.API.Models
{
    public class Product
    {
        [Required]
        [StringLength(15)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public List<Season> Season { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public List<Size> Size { get; set; }
    }
}
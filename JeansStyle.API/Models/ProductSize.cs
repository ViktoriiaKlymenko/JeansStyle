using JeansStyle.WEB.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace JeansStyle.WEB.Models
{
    public class ProductSize
    {
        public Guid Id { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        [Range(1, 100)]
        public int Amount { get; set; }
        [Required]
        public Size Size { get; set; }
    }
}

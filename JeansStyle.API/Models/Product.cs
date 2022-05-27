using JeansStyle.API.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JeansStyle.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Field Cannot be Blank Or Whitespace")]

        [StringLength(15)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public List<Season> Season { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public Size Size { get; set; }
        [Required]
        [Range(1, 100)]
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
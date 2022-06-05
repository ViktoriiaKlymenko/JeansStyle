using JeansStyle.WEB.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JeansStyle.WEB.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Field Cannot be Blank Or Whitespace")]

        [StringLength(15)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public List<string> SeasonId { get; set; }
        [Required]
        public string GenderId { get; set; }

        public IFormFile Image { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}

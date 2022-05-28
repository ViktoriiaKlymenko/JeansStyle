using JeansStyle.BLL.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JeansStyle.BLL.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public CategoryDto Category { get; set; }

        public List<Season> Season { get; set; }

        public Gender Gender { get; set; }
        public string Image { get; set; }

        public decimal Price { get; set; }
    }
}
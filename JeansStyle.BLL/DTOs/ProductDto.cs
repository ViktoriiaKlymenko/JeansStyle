using System;
using System.Collections.Generic;

namespace JeansStyle.BLL.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public CategoryDto Category { get; set; }

        public List<SeasonDto> Season { get; set; }

        public Guid GenderId { get; set; }
        public string Image { get; set; }

        public decimal Price { get; set; }
    }
}
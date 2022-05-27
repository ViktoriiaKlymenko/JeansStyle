using JeansStyle.API.Models;
using JeansStyle.API.Models.Enums;
using System;
using System.Collections.Generic;

namespace JeansStyle.API.Mapping
{
    public class ProductModelForMapping
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public List<Season> Season { get; set; }

        public Gender Gender { get; set; }
        public string Image { get; set; }

        public Size Size { get; set; }

        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}

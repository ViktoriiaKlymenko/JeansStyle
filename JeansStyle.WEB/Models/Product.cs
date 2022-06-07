using JeansStyle.WEB.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JeansStyle.WEB.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public List<Season> Seasons { get; set; }

        public Gender Gender{ get; set; }
        public string Image { get; set; }

        public decimal Price { get; set; }
    }
}
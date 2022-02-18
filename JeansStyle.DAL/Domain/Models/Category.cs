using System;
using System.Collections.Generic;

namespace JeansStyle.DAL.Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Product> Items { get; set; }
    }
}
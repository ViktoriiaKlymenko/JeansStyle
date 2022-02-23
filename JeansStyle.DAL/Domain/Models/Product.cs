using JeansStyle.DAL.Domain.Enums;
using System;
using System.Collections.Generic;

namespace JeansStyle.DAL.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<Season> Season { get; set; }
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public int Amount { get; set; }
        public List<Order> Orders { get; set; }
    }
}

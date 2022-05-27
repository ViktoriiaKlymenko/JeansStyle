using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.DTOs.Enums;
using JeansStyle.DAL.Domain.Models;
using System;
using System.Collections.Generic;

namespace JeansStyle.BLL.Mapping
{
    public class ProductModelForMapping
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CategoryDto Category { get; set; }
        public List<DAL.Domain.Models.Season> Season { get; set; }
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}

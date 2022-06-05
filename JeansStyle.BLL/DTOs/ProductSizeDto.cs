using JeansStyle.BLL.Mapping;
using System;

namespace JeansStyle.BLL.DTOs
{
    public class ProductSizeDto
    {
        public Guid Id { get; set; }
        public ProductDto Product { get; set; }
        public int Amount { get; set; }
        public SizeDto Size { get; set; }
    }
}

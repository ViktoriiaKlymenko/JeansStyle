using System;

namespace JeansStyle.WEB.Models
{
    public class Cart
    {
        public Guid ProductSizeId { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
    }
}

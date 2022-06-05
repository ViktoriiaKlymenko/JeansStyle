using System;

namespace JeansStyle.WEB.Models
{
    public class Cart
    {
        public Guid ProductId { get; set; }
        public Guid SizeId { get; set; }
        public int Amount { get; set; }
    }
}

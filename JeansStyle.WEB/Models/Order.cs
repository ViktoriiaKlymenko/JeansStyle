using System;
using System.Collections.Generic;

namespace JeansStyle.WEB.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
        public UserCredentials UserCredentials { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

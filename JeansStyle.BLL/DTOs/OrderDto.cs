using System.Collections.Generic;

namespace JeansStyle.BLL.DTOs
{
    public class OrderDto
    {
        public List<ProductSizeDto> ProductSizes { get; set; }
        public List<ProductDto> Products { get; set; }
        public UserCredentialsDto UserCredentials { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
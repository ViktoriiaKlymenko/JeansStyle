using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.DAL.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<Product> Products { get; set; }
        public UserCredentials UserCredentials { get; set; }
    }
}

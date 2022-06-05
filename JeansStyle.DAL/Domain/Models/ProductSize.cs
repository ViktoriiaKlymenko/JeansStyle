using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.DAL.Domain.Models
{
    public class ProductSize
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Amount { get; set; }
        public Guid SizeId { get; set; }
        public virtual Size Size { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }    
    }
}

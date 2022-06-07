using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.DAL.Domain.Models
{
    public class Order: AuditableEntity
    {
        public Guid Id { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
        public UserCredentials UserCredentials { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
    }
}

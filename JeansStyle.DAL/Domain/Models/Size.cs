using System;
using System.Collections.Generic;

namespace JeansStyle.DAL.Domain.Models
{
    public class Size: AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
    }
}
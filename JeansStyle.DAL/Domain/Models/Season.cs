using System;
using System.Collections.Generic;

namespace JeansStyle.DAL.Domain.Models
{
    public class Season: AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
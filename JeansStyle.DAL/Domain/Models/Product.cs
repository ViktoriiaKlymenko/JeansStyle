using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeansStyle.DAL.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ProductSize> ProductSizes { get; set; } //TODO
        public Guid CategoryId { get; set; }
        public virtual Category Categories { get; set; }
        public List<Season> Seasons { get; set; }
        public Guid GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public string Image { get; set; }
        
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
    }
}

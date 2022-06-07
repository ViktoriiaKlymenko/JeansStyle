using System;

namespace JeansStyle.DAL
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}

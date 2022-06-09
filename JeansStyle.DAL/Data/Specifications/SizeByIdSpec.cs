using Ardalis.Specification;
using JeansStyle.DAL.Domain.Models;
using System;

namespace JeansStyle.DAL.Data.Specifications
{
    public class SizeByIdSpec
     : Specification<Size>
    {
        public SizeByIdSpec(Guid id)
        {
            if (!(id == Guid.Empty))
                Query.Where(s => s.Id == id);
        }

    }
}

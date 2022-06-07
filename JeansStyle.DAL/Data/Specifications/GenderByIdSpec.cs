using Ardalis.Specification;
using JeansStyle.DAL.Domain.Models;
using System;

namespace JeansStyle.DAL.Data.Specifications
{
    public class GenderByIdSpec
     : Specification<Gender>
    {
        public GenderByIdSpec(Guid id)
        {
            if (!(id == Guid.Empty))
                Query.Where(g => g.Id == id);
        }

    }
}

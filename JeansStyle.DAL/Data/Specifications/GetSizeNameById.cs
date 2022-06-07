using Ardalis.Specification;
using JeansStyle.DAL.Domain.Models;
using System;

namespace JeansStyle.DAL.Data.Specifications
{
    public class GetSizeNameById : Specification<Size>
    {
        public GetSizeNameById(Guid id)
        {
            if (!(id == Guid.Empty))
                Query.Where(s => s.Id == id);
        }
    }
}
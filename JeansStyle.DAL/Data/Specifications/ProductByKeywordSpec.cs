using Ardalis.Specification;
using JeansStyle.DAL.Domain.Models;
using System;
using System.Linq.Expressions;

namespace JeansStyle.DAL.Data.Specifications
{
    public class ProductByKeywordSpec
       : Specification<Product>
    {
        public ProductByKeywordSpec(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                Query.Where(p => p.Title.Contains(keyword) || p.Description.Contains(keyword));
        }

    }
}

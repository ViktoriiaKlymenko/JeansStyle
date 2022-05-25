using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Interfaces
{
    public interface ISearchService
    {
        SearchResponse GetProductsByTitleAndDescription(string keyword);
        SearchResponse GetAllByCategory(string category);
        SearchResponse GetAll();
        List<string> GetAllCategories();
        ProductDto GetById(Guid id);
    }
}
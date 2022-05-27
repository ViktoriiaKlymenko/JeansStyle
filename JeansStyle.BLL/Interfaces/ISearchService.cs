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
        IEnumerable<string> GetAllCategoriesNames();
        List<CategoryDto> GetAllCategories();
        ProductDto GetById(Guid id);
        Guid GetCategoryIdByName(string name);
    }
}
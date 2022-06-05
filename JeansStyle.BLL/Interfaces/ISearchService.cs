using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Mapping;
using JeansStyle.BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Interfaces
{
    public interface ISearchService
    {
        SearchResponse GetProductsByTitleAndDescription(string keyword);
        //SearchResponse GetAllByCategory(string category);
        int Count();
        SearchResponse GetAll();
        IEnumerable<string> GetAllCategoriesNames();
        List<CategoryDto> GetAllCategories();
        ProductDto GetById(Guid id);
        ProductDto GetByIdWithReturningDto(Guid id);
        Guid GetCategoryIdByName(string name);
        SearchResponse GetAllProductsByCategoryId(Guid id);
        List<ProductSizeDto> GetProductSizesById(Guid id);
        List<SeasonDto> GetAllSeasons();
        List<GenderDto> GetAllGenders();
        CategoryDto GetCategoryById(Guid id);
        GenderDto GetGenderById(Guid id);
        List<SeasonDto> GetSeasonsById(List<string> ids);
        

    }
}
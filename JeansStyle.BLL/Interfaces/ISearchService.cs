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
        Task<SearchResponse> GetProductsByTitleAndDescription(string keyword);
        //SearchResponse GetAllByCategory(string category);
        int Count();
        SearchResponse GetAll();
        List<CategoryDto> GetAllCategories();
        ProductDto GetByIdWithReturningDto(Guid id);
        Guid GetCategoryIdByName(string name);
        SearchResponse GetAllProductsByCategoryId(Guid id);
        List<ProductSizeDto> GetProductSizesById(Guid productSizeId);
        List<SeasonDto> GetAllSeasons();
        List<GenderDto> GetAllGenders();
        Task<CategoryDto> GetCategoryById(Guid id);
        SizeDto GetSizeById(Guid sizeId);
        Task<GenderDto> GetGenderById(Guid id);
        List<SeasonDto> GetSeasonsById(List<string> ids);
        Task<ProductDto> GetProductById(Guid productId);
        Guid GetGenderByName(string gender);
    }
}
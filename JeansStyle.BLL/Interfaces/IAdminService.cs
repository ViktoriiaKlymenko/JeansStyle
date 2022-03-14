using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Interfaces
{
    public interface IAdminService
    {
        Task AddProduct(ProductDto product);

        Task UpdateProduct(ProductDto product);

        Task DeleteProduct(ProductDto product);
        Task<SearchResponse> GetAllProducts();
    }
}

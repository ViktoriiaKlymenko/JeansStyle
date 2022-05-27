using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Interfaces
{
    public interface IAdminService
    {
        void AddProduct(ProductDto product);

        void UpdateProduct(ProductDto product);

        void DeleteProduct(ProductDto product);
        SearchResponse GetAllProducts();
    }
}

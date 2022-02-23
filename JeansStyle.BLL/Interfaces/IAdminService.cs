using JeansStyle.BLL.DTOs;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Interfaces
{
    public interface IAdminService
    {
        Task AddProduct(ProductDto product);

        Task UpdateProduct(ProductDto product);

        Task DeleteProduct(ProductDto product);
    }
}

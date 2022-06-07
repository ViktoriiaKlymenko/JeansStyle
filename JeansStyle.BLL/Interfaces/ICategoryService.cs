using JeansStyle.BLL.Models;
using JeansStyle.DAL.Data.Specifications;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoriesByGenderDto> GetCategoriesByGender();
    }
}
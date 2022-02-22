using JeansStyle.BLL.Models;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Interfaces
{
    public interface ISearchService
    {
        Task<SearchResponse> GetProductsByTitleAndDescription(string keyword);
    }
}
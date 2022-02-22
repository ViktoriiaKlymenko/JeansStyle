using JeansStyle.BLL.Interfaces;
using JeansStyle.BLL.Models;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using JeansStyle.DAL.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Services
{
    public class SearchService : ISearchService
    {
        private readonly IBaseRepository<Product> _baseRepository;

        public SearchService(IBaseRepository<Product> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<SearchResponse> GetProductsByTitleAndDescription(string keyword)
        {
            var searchResponse = new SearchResponse();
            searchResponse.Products = _baseRepository.FindAllWhere(p => p.Title == keyword);
            searchResponse.Products.AddRange(_baseRepository.FindAllWhere(p => p.Description.Contains(keyword)));
            return searchResponse;
        }
    }
}

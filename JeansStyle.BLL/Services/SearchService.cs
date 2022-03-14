using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.BLL.Models;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using JeansStyle.DAL.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Services
{
    public class SearchService : ISearchService
    {
        private readonly IBaseRepository<Product> _repository;
        private readonly IMapper _mapper;

        public SearchService(IBaseRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<SearchResponse> GetProductsByTitleAndDescription(string keyword)
        {
            var searchResponse = new SearchResponse();
            searchResponse.Products = _repository.FindAllWhere(p => p.Title == keyword);
            searchResponse.Products.AddRange(_repository.FindAllWhere(p => p.Description.Contains(keyword)));
            return searchResponse;
        }

        public async Task<SearchResponse> GetAllByCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var searchResponse = new SearchResponse
            {
                Products = _repository.FindAllWhere(p => p.Category == category)
            };

            return searchResponse;
        }
    }
}
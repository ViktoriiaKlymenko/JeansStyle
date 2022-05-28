using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.BLL.Models;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using JeansStyle.DAL.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Services
{
    public class SearchService : ISearchService
    {
        private readonly IBaseRepository<Product> _repository;
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public SearchService(IBaseRepository<Product> repository, IBaseRepository<Category> categoryRepository, IMapper mapper)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public SearchResponse GetProductsByTitleAndDescription(string keyword)
        {
            var searchResponse = new SearchResponse();
            searchResponse.Products = _repository.FindAllWhere(p => p.Title.Contains(keyword));
            searchResponse.Products.AddRange(_repository.FindAllWhere(p => p.Description.Contains(keyword)));
            return searchResponse;
        }

        public SearchResponse GetAllProductsByCategoryId(Guid id)
        {
            var products = _repository.GetAll();
            var searchResponse = new SearchResponse
            {
                Products = _repository.FindAllWhere(p => p.CategoryId == id)
            };


            return searchResponse;
        }

        public Guid GetCategoryIdByName(string name)
        {
            return _categoryRepository.FindWhere(c => c.Name == name).Id;
        }

        public IEnumerable<string> GetAllCategoriesNames()
        {
            var smth = _categoryRepository.GetAll();
            var names = smth.Select(s=>s.Name);
            return names;
        }

        public List<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            var categoriesDto = new List<CategoryDto>();   
            foreach(var category in categories)
            {
                categoriesDto.Add(_mapper.Map<CategoryDto>(category));
            }

            return categoriesDto;
        }

        public SearchResponse GetAll()
        {
            var searchResponse = new SearchResponse
            {
                Products = _repository.GetAll()
            };

            return searchResponse;
        }

        public int Count()
        {
            return _repository.Count();
        }

        public ProductDto GetById(Guid id)
        {
            var product = _repository.FindWhere(p => p.Id == id);
            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }
    }
}
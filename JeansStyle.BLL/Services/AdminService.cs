using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.BLL.Models;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using JeansStyle.DAL.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IBaseRepository<Product> _repository;
        private readonly IBaseRepository<Category> _categoryRepository;

        private readonly IMapper _mapper;

        public AdminService(IBaseRepository<Product> baseRepository, IMapper mapper, IBaseRepository<Category> categoryRepository)
        {
            _repository = baseRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public void AddProduct(ProductDto productDto)
        {
            var categoryId = _categoryRepository.FindWhere(c => c.Name == productDto.Category.Name).Id;
            productDto.Category.Id = categoryId;
            var product = _mapper.Map<Product>(productDto);
            _repository.Add(product);
        }

        public void UpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _repository.Update(product);
        }

        public void DeleteProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _repository.Delete(product);
        }

        public SearchResponse GetAllProducts()
        {
            var searchResponse = new SearchResponse
            {
                Products = _repository.GetAll()
            };

            return searchResponse;
        }
    }
}
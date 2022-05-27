using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.BLL.Mapping;
using JeansStyle.BLL.Models;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using JeansStyle.DAL.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IBaseRepository<Product> _repository;
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IBaseRepository<Season> _seasonRepository;

        private readonly IMapper _mapper;

        public AdminService(IBaseRepository<Product> baseRepository, IMapper mapper, IBaseRepository<Category> categoryRepository, IBaseRepository<Season> seasonRepository)
        {
            _repository = baseRepository;
            _mapper = mapper;
            _seasonRepository = seasonRepository;
            _categoryRepository = categoryRepository;
        }

        public void AddProduct(ProductDto productDto)
        {
            var season = _seasonRepository.FindAllWhere(s => s.Name == productDto.Season.ToString());
            var productModelForMapping = new ProductModelForMapping
            {
                Amount = productDto.Amount,
                Season = season,
                Category = productDto.Category,
                Gender=productDto.Gender,   
                Description = productDto.Description,   
                Image=productDto.Image, 
                Price=productDto.Price,
                Title = productDto.Title
            };
            var product = _mapper.Map<Product>(productModelForMapping);
            
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
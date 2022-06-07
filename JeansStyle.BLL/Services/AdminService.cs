using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.BLL.Mapping;
using JeansStyle.BLL.Models;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using JeansStyle.DAL.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            var product = _mapper.Map<Product>(productDto);
            
            _repository.Add(product);
            _repository.Clear();
        }

        public void UpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _repository.Update(product);
            _repository.Clear();
        }

        public void DeleteProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _repository.Delete(product);
            _repository.Clear();
        }

        public SearchResponse GetAllProducts()
        {
            var searchResponse = new SearchResponse
            {
                Products = _mapper.Map<List<ProductDto>>(_repository.GetAll())
            };
            _repository.Clear();
            return searchResponse;
        }

        public void Update(Guid productId, ProductDto productDto)
        {
            var season = _seasonRepository.FindAllWhere(s => s.Name == productDto.Season.ToString());
            productDto.Season = _mapper.Map<List<SeasonDto>>(season);
            var product = _mapper.Map<Product>(productDto);

            _repository.Update(product);
            _repository.Clear();
        }
    }
}
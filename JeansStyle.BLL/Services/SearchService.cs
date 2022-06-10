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
using System.Linq;
using System.Threading.Tasks;
using JeansStyle.DAL.Data.Specifications;
using System.Diagnostics;

namespace JeansStyle.BLL.Services
{
    public class SearchService : ISearchService
    {
        private readonly IBaseRepository<Product> _repository;
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IBaseRepository<Season> _seasonRepository;
        private readonly IBaseRepository<Gender> _genderRepository;
        private readonly IBaseRepository<ProductSize> _productSizeRepository;
        private readonly IBaseRepository<Size> _sizeRepository;
        private readonly IMapper _mapper;

        public SearchService(IBaseRepository<Product> repository, IBaseRepository<Category> categoryRepository,
            IBaseRepository<Season> seasonRepository,
            IBaseRepository<Gender> genderRepository,
            IBaseRepository<Size> sizeRepository,
            IMapper mapper)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _seasonRepository = seasonRepository;
            _genderRepository = genderRepository;
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public async Task<SearchResponse> GetProductsByTitleAndDescription(string keyword)
        {
            var searchResponse = new SearchResponse();
            searchResponse.Products = _mapper.Map<List<ProductDto>>(await _repository.ListAsync(new ProductByKeywordSpec(keyword)));

            return searchResponse;
        }

        public SearchResponse GetAllProductsByCategoryId(Guid id)
        {
            var products = _repository.GetAll();
            var searchResponse = new SearchResponse
            {
                Products = _mapper.Map<List<ProductDto>>(_repository.FindAllWhere(p => p.CategoryId == id))
            };
            _repository.Clear();

            return searchResponse;
        }

        public Guid GetCategoryIdByName(string name)
        {
             var id = _categoryRepository.FindWhere(c => c.Name == name).Id;
            _categoryRepository.Clear();
            return id;
        }

        public List<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            var categoriesDto = new List<CategoryDto>();
            foreach (var category in categories)
            {
                categoriesDto.Add(_mapper.Map<CategoryDto>(category));
            }
            _categoryRepository.Clear();

            return categoriesDto;
        }

        public SearchResponse GetAll()
        {
            var searchResponse = new SearchResponse
            {
                Products = _mapper.Map<List<ProductDto>>(_repository.GetAll())
            };
            _repository.Clear();

            return searchResponse;
        }

        public int Count()
        {
            return _repository.Count();
        }

        public async Task<ProductDto> GetProductById(Guid id)
        {
            var productDto = _mapper.Map<ProductDto>(await _repository.GetBySpecAsync(new ProductByIdSpec(id)));
            _repository.Clear();

            return productDto;
        }
        public ProductDto GetByIdWithReturningDto(Guid id)
        {
            var product = _repository.FindWhere(p => p.Id == id);
            var productDto = _mapper.Map<ProductDto>(product);
            _repository.Clear();

            return productDto;
        }

        public List<ProductSizeDto> GetProductSizesById(Guid productId, Guid sizeId)
        {
            return _mapper.Map<List<ProductSizeDto>>(_productSizeRepository.ListAsync(new ProductSizeByProductIdAndSizeId(productId, sizeId)));
        }

        public List<SeasonDto> GetAllSeasons()
        {
            return _mapper.Map<List<SeasonDto>>(_seasonRepository.GetAll());
        }

        public List<GenderDto> GetAllGenders()
        {
            return _mapper.Map<List<GenderDto>>(_genderRepository.GetAll());
        }

        public async Task<CategoryDto> GetCategoryById(Guid id)
        {
            return _mapper.Map<CategoryDto>(await _categoryRepository.GetBySpecAsync(new CategoryByIdSpec(id)));
        }

        public async Task<GenderDto> GetGenderById(Guid id)
        {
            return _mapper.Map<GenderDto>(await _genderRepository.GetBySpecAsync(new GenderByIdSpec(id)));
        }

        public List<SeasonDto> GetSeasonsById(List<string> ids)
        {
            var seasons = new List<SeasonDto>();
            foreach (var id in ids)
            {
                seasons.Add(_mapper.Map<SeasonDto>(_seasonRepository.FindWhere(s => s.Id == Guid.Parse(id))));
            }
            return seasons;
        }

        public List<ProductSizeDto> GetProductSizesById(Guid id)
        {
            throw new NotImplementedException();
        }

    

        public SizeDto GetSizeById(Guid sizeId)
        {
            return _mapper.Map<SizeDto>(_sizeRepository.FindWhere(s => s.Id == sizeId));
        }

        public Guid GetGenderByName(string gender)
        {
            return _genderRepository.FindWhere(g=>g.Name == gender).Id;
        }
    }
}
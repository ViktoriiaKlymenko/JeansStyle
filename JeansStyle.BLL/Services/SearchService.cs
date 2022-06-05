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

        public SearchResponse GetProductsByTitleAndDescription(string keyword)
        {
            var searchResponse = new SearchResponse();
            searchResponse.Products = _mapper.Map<List<ProductDto>>(_repository.FindAllWhere(p => p.Title.ToLower().Contains(keyword.ToLower())));
            searchResponse.Products.AddRange(_mapper.Map<List<ProductDto>>(_repository.FindAllWhere(p => p.Description.ToLower().Contains(keyword.ToLower()))));
            searchResponse.Products.Distinct();
            return searchResponse;
        }

        public SearchResponse GetAllProductsByCategoryId(Guid id)
        {
            var products = _repository.GetAll();
            var searchResponse = new SearchResponse
            {
                Products = _mapper.Map<List<ProductDto>>(_repository.FindAllWhere(p => p.CategoryId == id))
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
            var names = smth.Select(s => s.Name);
            return names;
        }

        public List<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            var categoriesDto = new List<CategoryDto>();
            foreach (var category in categories)
            {
                categoriesDto.Add(_mapper.Map<CategoryDto>(category));
            }

            return categoriesDto;
        }

        public SearchResponse GetAll()
        {
            var searchResponse = new SearchResponse
            {
                Products = _mapper.Map<List<ProductDto>>(_repository.GetAll())
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
        public ProductDto GetByIdWithReturningDto(Guid id)
        {
            var product = _repository.FindWhere(p => p.Id == id);
            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public List<ProductSizeDto> GetProductSizesById(Guid productId, Guid sizeId)
        {
            return _mapper.Map<List<ProductSizeDto>>(_productSizeRepository.FindAllWhere(ps => ps.ProductId == productId).Where(ps => ps.SizeId == sizeId));
        }

        public List<SeasonDto> GetAllSeasons()
        {
            return _mapper.Map<List<SeasonDto>>(_seasonRepository.GetAll());
        }

        public List<GenderDto> GetAllGenders()
        {
            return _mapper.Map<List<GenderDto>>(_genderRepository.GetAll());
        }

        public CategoryDto GetCategoryById(Guid id)
        {
            return _mapper.Map<CategoryDto>(_categoryRepository.FindWhere(c => c.Id == id));
        }

        public GenderDto GetGenderById(Guid id)
        {
            return _mapper.Map<GenderDto>(_genderRepository.FindWhere(g => g.Id == id));
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

        public ProductDto GetProductById(Guid productId)
        {
            return _mapper.Map<ProductDto>(_repository.FindWhere(p => p.Id == productId));
        }

        public SizeDto GetSizeById(Guid sizeId)
        {
            return _mapper.Map<SizeDto>(_sizeRepository.FindWhere(s => s.Id == sizeId));
        }
    }
}
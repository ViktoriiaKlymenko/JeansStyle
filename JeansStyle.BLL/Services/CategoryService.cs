using AutoMapper;
using JeansStyle.BLL.Interfaces;
using JeansStyle.BLL.Models;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using JeansStyle.DAL.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace JeansStyle.BLL.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ISearchService _searchService;


        public CategoryService(IBaseRepository<Category> categoryRepository, IMapper mapper, ISearchService searchService)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _searchService = searchService;
        }

        public CategoriesByGender GetCategoriesByGender()
        {
            var categoriesByGender = new CategoriesByGender
            {
                Men = new List<Category>(),
                Women = new List<Category>()
            };
            var categoriesDto = _searchService.GetAllCategories();
            var categories = _mapper.Map<List<Category>>(categoriesDto);

            //categoriesByGender.Men = categories.Where(c => c.Products.Any(p => (int)p.Gender == 0)).Distinct().ToList();
            //categoriesByGender.Women = categories.Where(c => c.Products.Any(p => (int)p.Gender == 1)).Distinct().ToList();

            return categoriesByGender;


        }
    }
}

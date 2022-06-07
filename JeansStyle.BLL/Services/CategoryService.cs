using AutoMapper;
using JeansStyle.BLL.Interfaces;
using JeansStyle.BLL.Models;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using JeansStyle.DAL.Data.Specifications;
using JeansStyle.DAL.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<CategoriesByGenderDto> GetCategoriesByGender()
        {
            var categoriesByGender = new CategoriesByGender
            {
                Men = new List<Category>(),
                Women = new List<Category>()
            };


            categoriesByGender.Men = await _categoryRepository.ListAsync(new CategoriesByGenderMenSpec());
            categoriesByGender.Women = await _categoryRepository.ListAsync(new CategoriesByGenderWomenSpec());
            _categoryRepository.Clear();
            return _mapper.Map<CategoriesByGenderDto>(categoriesByGender);


        }
    }
}

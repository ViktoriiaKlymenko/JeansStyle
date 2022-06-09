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
        private readonly IBaseRepository<Gender> _genderRepository;
        private readonly IMapper _mapper;
        private readonly ISearchService _searchService;


        public CategoryService(IBaseRepository<Category> categoryRepository, IMapper mapper, ISearchService searchService, IBaseRepository<Gender> genderRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _searchService = searchService;
            _genderRepository = genderRepository;
        }

        public async Task<CategoriesByGenderDto> GetCategoriesByGender()
        {
            var categoriesByGender = new CategoriesByGender
            {
                Men = new List<Category>(),
                Women = new List<Category>()
            };
            var men = await _genderRepository.GetBySpecAsync(new GetGenderIdByName("Men"));
            var women = await _genderRepository.GetBySpecAsync(new GetGenderIdByName("Women"));

            if (men != null)
            {
                categoriesByGender.Men = await _categoryRepository.ListAsync(new CategoriesByGenderIdSpec(men.Id));
            }
            if (women != null)
            {
                categoriesByGender.Women = await _categoryRepository.ListAsync(new CategoriesByGenderIdSpec(women.Id));
            }
            _categoryRepository.Clear();
            return _mapper.Map<CategoriesByGenderDto>(categoriesByGender);


        }
    }
}

using AutoMapper;
using JeansStyle.BLL.Interfaces;
using JeansStyle.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace JeansStyle.WEB.Components
{
    [ViewComponent(Name = "Menu")]
    public class Menu
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public Menu(ISearchService searchService, IMapper mapper, ICategoryService categoryService)
        {
            _searchService = searchService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        // public IViewComponentResult Invoke()
        // {
        //     var modelDto = _categoryService.GetCategoriesByGender();
        //     var model = _mapper.Map<CategoriesByGenderViewModel>(modelDto);
        //
        //     return View("_PartialView", model);
        // }
    }
}

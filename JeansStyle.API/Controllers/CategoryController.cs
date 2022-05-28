using AutoMapper;
using JeansStyle.API.Models;
using JeansStyle.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace JeansStyle.API.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(ISearchService searchService, IMapper mapper, ICategoryService categoryService)
        {
            _searchService = searchService;
            _mapper = mapper;
            _categoryService = categoryService; 
        }

        public PartialViewResult Index()
        {
           

            var modelDto = _categoryService.GetCategoriesByGender();
            var model = _mapper.Map<CategoriesByGenderViewModel>(modelDto);

            return PartialView("~/Views/Shared/_PartialView.cshtml", model);

        }
    }
}



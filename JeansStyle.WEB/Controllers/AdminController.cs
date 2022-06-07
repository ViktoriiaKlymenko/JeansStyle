using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.BLL.Models;
using JeansStyle.WEB.Models;
using JeansStyle.WEB.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.WEB.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly IAdminService _adminService;
        private readonly ISizeService _sizeService;
        private readonly IProductSizeService _productSizeService;
        private readonly IMapper _mapper;

        public AdminController(ISearchService searchService, IAdminService adminService, IMapper mapper, ISizeService sizeService, IProductSizeService productSizeService)
        {
            _searchService = searchService;
            _adminService = adminService;
            _mapper = mapper;
            _sizeService = sizeService;
            _productSizeService = productSizeService;
        }

        public ActionResult Index()
        {
            ViewBag.ProductsCount = _searchService.Count();
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            var productDto = _searchService.GetByIdWithReturningDto(id);

            _adminService.DeleteProduct(productDto);

            return RedirectToAction("Index");
        }


        public ActionResult GetProducts()
        {
            var products = _searchService.GetAll().Products;

            ViewBag.Products = _searchService.GetAll().Products;
            return View();
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            var categories = _searchService.GetAllCategories();
            var seasons = _searchService.GetAllSeasons();
            var genders = _searchService.GetAllGenders();

            var categoriesSelect = new List<SelectListItem>();
            foreach (var category in categories)
            {
                SelectListItem c = new SelectListItem();
                c.Text = category.Name;
                c.Value = category.Id.ToString();
                
                categoriesSelect.Add(c);
            }

            var seasonsSelect = new List<SelectListItem>();
            foreach (var season in seasons)
            {
                SelectListItem c = new SelectListItem();
                c.Text = season.Name;
                c.Value = season.Id.ToString();
                seasonsSelect.Add(c);
            }

            var gendersSelect = new List<SelectListItem>();
            foreach (var gender in genders)
            {
                SelectListItem c = new SelectListItem();
                c.Text = gender.Name;
                c.Value = gender.Id.ToString();
                gendersSelect.Add(c);
            }




            ViewBag.Categories = categoriesSelect;
            ViewBag.Genders = gendersSelect;
            ViewBag.Seasons = seasonsSelect;


            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductViewModel productViewModel)
        {
            var product = new Product();


            if (ModelState.IsValid)
            {
                string filePath = "/images/clothes/" + productViewModel.Image.FileName;
                using (var fileStream = new FileStream("wwwroot" + filePath, FileMode.OpenOrCreate))
                {
                    await productViewModel.Image.CopyToAsync(fileStream);
                }

                productViewModel.Title = string.Join(" ", productViewModel.Title.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

                var category = _mapper.Map<Category>(_searchService.GetCategoryById(Guid.Parse(productViewModel.CategoryId)));
                var gender = _mapper.Map<Gender>(_searchService.GetGenderById(Guid.Parse(productViewModel.GenderId)));
                var seasons = _mapper.Map<List<Season>>(_searchService.GetSeasonsById(productViewModel.SeasonId));

                product = new Product()
                {
                    Category = category,
                    Description = productViewModel.Description,
                    Gender = gender,
                    Image = filePath,
                    Price = productViewModel.Price,
                    Seasons = seasons,
                    Title = productViewModel.Title
                };

                var productDto = _mapper.Map<ProductDto>(product);

                _adminService.AddProduct(productDto);
                return RedirectToAction("GetProducts");
            }

            return View(product);
        }


        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Update(Guid id)
        {
            var categories = _searchService.GetAllCategories();
            var productDto = _searchService.GetById(id);
            var product = _mapper.Map<Product>(productDto);

            ViewBag.Categories = categories;


            return View(product);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Update()
        {
            var product = new ProductViewModel();

            if (ModelState.IsValid)
            {
                string filePath = "/images/clothes/" + product.Image.FileName;
                using (var fileStream = new FileStream("wwwroot" + filePath, FileMode.OpenOrCreate))
                {
                    await product.Image.CopyToAsync(fileStream);
                }

                var productDto = _mapper.Map<ProductDto>(product);

                _adminService.Update(product.Id, productDto);
                return RedirectToAction("GetProducts");
            }

            return View(product);
        }
    }

}


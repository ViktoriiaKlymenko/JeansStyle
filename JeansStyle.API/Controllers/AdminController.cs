using AutoMapper;
using JeansStyle.API.Mapping;
using JeansStyle.API.Models;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.API.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(ISearchService searchService, IAdminService adminService, IMapper mapper)
        {
            _searchService = searchService;
            _adminService = adminService;
            _mapper = mapper;
        }

        public ActionResult Delete(Guid id)
        {
            var product = _searchService.GetById(id);
            _adminService.DeleteProduct(product);
            return View();
        }

        [HttpGet]
        public ActionResult AddProductSizes(Guid id)
        {
            var productDto = _searchService.GetById(id);
            ViewBag.Product = _mapper.Map<Product>(productDto);
            return View();
        }

        [HttpPost]
        public ActionResult AddProductSizes(Product product, int amount, Size size)
        {
            ViewBag.Products = _searchService.GetAll().Products;
            return View();
        }

        public ActionResult GetProducts()
        {
            ViewBag.Products = _searchService.GetAll().Products;
            return View();
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            var allCategories = _searchService.GetAllCategories();
            SelectList categories = new SelectList(allCategories, "Id", "Name");
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {

            if (ModelState.IsValid)
            {
                string filePath = "/images/clothes/" + product.Image.FileName;
                using (var fileStream = new FileStream("wwwroot"+filePath, FileMode.OpenOrCreate))
                {
                    await product.Image.CopyToAsync(fileStream);
                }

                var category = new Category
                {
                    Id = _searchService.GetCategoryIdByName(product.Category),
                    Name = product.Category
                };

                var productModelForMapping = new ProductModelForMapping
                {
                    Title = product.Title,
                    Description = product.Description,
                    Category = category,
                    Season = product.Season,
                    Gender = product.Gender,
                    Image = filePath,
Price = product.Price,
                };

                var productDto = _mapper.Map<ProductDto>(productModelForMapping);

                _adminService.AddProduct(productDto);
                return RedirectToAction("GetProducts");
            }

            return View(product);
        }
    }
}

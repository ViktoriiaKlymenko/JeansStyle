using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.WEB.Models;
using JeansStyle.WEB.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansStyle.WEB.Controllers
{
    public class ProductSizeController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly IAdminService _adminService;
        private readonly ISizeService _sizeService;
        private readonly IProductSizeService _productSizeService;
        private readonly IMapper _mapper;

        public ProductSizeController(ISearchService searchService, IAdminService adminService, IMapper mapper, ISizeService sizeService, IProductSizeService productSizeService)
        {
            _searchService = searchService;
            _adminService = adminService;
            _mapper = mapper;
            _sizeService = sizeService;
            _productSizeService = productSizeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetProductSizes(Guid id)
        {
            var productDto = await _searchService.GetProductById(id);
            var sizes = _mapper.Map<List<Size>>(_sizeService.GetAll());
            //var productSizes = _searchService.GetProductSizesById(id);
            var sizeSelect = new List<SelectListItem>();
            foreach (var size in sizes)
            {
                SelectListItem c = new SelectListItem();
                c.Text = size.Name;
                c.Value = size.Id.ToString();
                sizeSelect.Add(c);
            }
            ViewBag.Product = productDto;
            ViewBag.Sizes = sizeSelect;
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> AddProductSize(Guid id)
        {
            var productDto = await _searchService.GetProductById(id);
            ViewBag.Product = productDto;
            var sizes = _mapper.Map<List<Size>>(_sizeService.GetAll());
            
            var sizesSelect = new List<SelectListItem>();
            foreach (var size in sizes)
            {
                SelectListItem c = new SelectListItem();
                c.Text = size.Name;
                c.Value = size.Id.ToString();
                sizesSelect.Add(c);
            }
            ViewBag.Sizes = sizesSelect;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProductSize(Guid productId, Size size, int amount)
        {
            if (ModelState.IsValid)
            {
                var productDto = await _searchService.GetProductById(productId);

                var sizeDto = await _sizeService.GetById(size.Id);
                var productSizeDto = new ProductSizeDto()
                {
                    Product = productDto,
                    Size = sizeDto,
                    Amount=amount
                };

                _productSizeService.AddProductSizes(productSizeDto);
                return RedirectToAction("GetProductDetails", "Admin", productId);
            }
            return View("NotFound");
        }
    }
}

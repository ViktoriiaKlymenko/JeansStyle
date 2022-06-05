using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.WEB.Models;
using JeansStyle.WEB.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

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
        public ActionResult GetProductSizes(Guid id)
        {
            var productDto = _searchService.GetById(id);
            //var productSizes = _searchService.GetProductSizesById(id);
            ViewBag.Product = productDto;
            ViewBag.Sizes = _mapper.Map<List<Size>>(_sizeService.GetAll());
            return View();
        }


        [HttpGet]
        public ActionResult AddProductSize(Guid id)
        {
            var productDto = _searchService.GetById(id);
            ViewBag.Product = productDto;
            var sizes = _mapper.Map<List<Size>>(_sizeService.GetAll());
            ViewBag.Sizes = sizes;
            var sizesSelect = new List<SelectListItem>();
            foreach (var size in sizes)
            {
                SelectListItem c = new SelectListItem();
                c.Text = size.Name;
                c.Value = size.Id.ToString();
                sizesSelect.Add(c);
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddProductSize(Guid productId, Size size, int amount)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(_searchService.GetProductById(productId));

                var productSize = new ProductSize()
                {
                    Product = product,
                    Size = size,
                    Amount=amount
                };
                var productSizeDto = _mapper.Map<ProductSizeDto>(productSize);

                _productSizeService.AddProductSizes(productSizeDto);
            }
            return View("NotFound");
        }
    }
}

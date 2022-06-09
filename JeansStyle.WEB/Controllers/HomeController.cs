using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JeansStyle.BLL.Interfaces;
using JeansStyle.WEB.Models;
using JeansStyle.WEB.Models.Enums;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace JeansStyle.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;
        private readonly ISizeService _sizeService;
        private readonly IProductSizeService _productSizeService;

        public HomeController(ILogger<HomeController> logger, ISearchService searchService, IMapper mapper, ISizeService sizeService, IProductSizeService productSizeService)
        {
            _searchService = searchService;
            _mapper = mapper;
            _sizeService = sizeService;
            _productSizeService = productSizeService;
        }

        public async Task<ActionResult> GetProducts([FromQuery] SearchRequest searchRequest)
        {
            if (ModelState.IsValid)
            {

                var products = await _searchService.GetProductsByTitleAndDescription(searchRequest.Request);
                if (products.Products.Count == 0)
                {
                    ViewBag.Request = searchRequest;
                    return View("NotFound");
                }
                var productsToView = new List<ProductViewModelWithSizes>();

                foreach (var product in products.Products)
                {
                    var productSizes = _mapper.Map<List<Size>>(await _productSizeService.GetSizeByProductId(product.Id));
                    foreach(var productSize in productSizes)
                    {
                        productSize.Name = await _productSizeService.GetNameById(productSize.Id);
                    }
                    productsToView.Add(new ProductViewModelWithSizes
                    {
                        Id = product.Id,
                        Category = _mapper.Map<Category>(await _searchService.GetCategoryById(product.Category.Id)),
                        Description = product.Description,
                        Title = product.Title,
                        Image = product.Image,
                        Price = product.Price,
                        Season = _mapper.Map<List<Season>>(product.Season),
                        Gender = _mapper.Map<Gender>(await _searchService.GetGenderById(product.GenderId)),
                        Sizes = productSizes
                    });
                    
                }
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
                ViewBag.Products = productsToView;
                return View();
            }
            ViewBag.Message = searchRequest.Request;
            return View("NotFound");
        }

        // public ActionResult GetProductCard([FromQuery] string searchRequest)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         var products = _searchService.GetProductsByTitleAndDescription(searchRequest);
        //         if (products.Products.Count == 0)
        //         {
        //             ViewBag.Request = searchRequest;
        //             return View("NotFound");
        //         }
        //         ViewBag.Products = products.Products;
        //         return View();
        //     }
        //     ViewBag.Request = searchRequest;
        //     return View("NotFound");
        // }

        [HttpGet]
        public ActionResult GetProductByCategory([FromQuery] string category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoryId = _searchService.GetCategoryIdByName(category);
                    var products = _searchService.GetAllProductsByCategoryId(categoryId).Products;
                    ViewBag.Products = products;
                    return View("GetProducts");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = category;
                    return View("NotFound");
                }

            }

            return BadRequest(ModelState);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

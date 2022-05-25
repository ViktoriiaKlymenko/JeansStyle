using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JeansStyle.API.Models;
using JeansStyle.BLL.Models;
using JeansStyle.BLL.Interfaces;

namespace JeansStyle.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchService _searchService;

        public HomeController(ILogger<HomeController> logger, ISearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }

        public async Task<ActionResult<SearchResponse>> GetProducts([FromQuery] string searchRequest)
        {
            if (ModelState.IsValid)
            {
                var products = _searchService.GetProductsByTitleAndDescription(searchRequest);
                if(products.Products.Count == 0)
                {
                    ViewBag.Request = searchRequest;
                    return View("NotFound");
                }
                ViewBag.Products = products.Products;
                return View();
            }
            ViewBag.Request = searchRequest;
            return View("NotFound");
        }

        public async Task<ActionResult<SearchResponse>> GetProductCard([FromQuery] string searchRequest)
        {
            if (ModelState.IsValid)
            {
                var products = _searchService.GetProductsByTitleAndDescription(searchRequest);
                if (products.Products.Count == 0)
                {
                    ViewBag.Request = searchRequest;
                    return View("NotFound");
                }
                ViewBag.Products = products.Products;
                return View();
            }
            ViewBag.Request = searchRequest;
            return View("NotFound");
        }

        [HttpGet]
        public async Task<ActionResult<SearchResponse>> GetProductByCategory([FromQuery] string category)
        {
            ViewBag.ActionType = "GetProductsByCategory";
            if (ModelState.IsValid)
            {
                var categoryName = category.ToString();
                var products = _searchService.GetAllByCategory(categoryName);
                if (products.Products.Count == 0)
                {
                    ViewBag.Request = category;
                    return View("NotFound");
                }
              
                ViewBag.Products = products;
                return View("GetProducts");
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

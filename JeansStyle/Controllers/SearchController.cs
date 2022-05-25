using AutoMapper;
using JeansStyle.API.Models;
using JeansStyle.BLL.Interfaces;
using JeansStyle.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JeansStyle.API.Controllers
{
    [Controller]
    [Route("[controller]/[action]")]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public async Task<ActionResult<SearchResponse>> GetProducts([FromQuery] SearchRequest searchRequest)
        {
            if (ModelState.IsValid)
            {
                return await _searchService.GetProductsByTitleAndDescription(searchRequest.Request);
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<ActionResult<SearchResponse>> GetProductByCategory([FromQuery] Category category)
        {
            if (ModelState.IsValid)
            {
                var categoryName = category.ToString();
                return await _searchService.GetAllByCategory(categoryName);
            }

            return BadRequest(ModelState);
        }
    }
}

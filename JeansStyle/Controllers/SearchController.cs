using JeansStyle.API.Models;
using JeansStyle.BLL.Interfaces;
using JeansStyle.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JeansStyle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
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
    }
}

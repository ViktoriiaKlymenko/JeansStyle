using AutoMapper;
using JeansStyle.API.Models;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JeansStyle.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

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

        [HttpGet]
        public async Task<ActionResult<SearchResponse>> GetProductByCategory([FromQuery] Category category)
        {
            if (ModelState.IsValid)
            {
                var categoryDto = _mapper.Map<CategoryDto>(category);
                return await _searchService.GetAllByCategory(categoryDto);
            }
           
            return BadRequest(ModelState);
        }
    }
}

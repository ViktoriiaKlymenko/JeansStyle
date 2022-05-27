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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> AddProductToDb([FromQuery] Product product)
        {
            if (ModelState.IsValid)
            {
                var productDto = _mapper.Map<ProductDto>(product);
                await _adminService.AddProduct(productDto);
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<ActionResult> RemoveProductFromDb([FromQuery] Product product)
        {
            if (ModelState.IsValid)
            {
                var productDto = _mapper.Map<ProductDto>(product);
                await _adminService.DeleteProduct(productDto);
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<ActionResult<SearchResponse>> GetProductsFromDb()
        {
            if (ModelState.IsValid)
            {
                return await _adminService.GetAllProducts();
            }

            return BadRequest(ModelState);
        }
    }
}
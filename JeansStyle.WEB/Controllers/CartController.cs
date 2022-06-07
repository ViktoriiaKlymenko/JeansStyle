using AutoMapper;
using JeansStyle.BLL.Interfaces;
using JeansStyle.WEB.Models;
using JeansStyle.WEB.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace JeansStyle.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;
        public CartController(ISearchService searchService, IMapper mapper)
        {

            _searchService = searchService;
            _mapper = mapper;

        }

        public async Task<string> GetData(Cart cart)
        {
            var product = _mapper.Map<Product>(await _searchService.GetProductById(cart.ProductId));
            var size = _mapper.Map<Size>(_searchService.GetSizeById(cart.SizeId));
            var productSize = _mapper.Map<ProductSize>(_searchService.GetProductSizesById(product.Id, cart.SizeId));
            var model = new CartApiModel()
            {

                Product = product,
                ProductSize = productSize,
                Amount = cart.Amount,
                TotalPrice = cart.Amount * product.Price
            };

            var modelSerialized = JsonSerializer.Serialize(model);

            return modelSerialized;
        }


    }
}

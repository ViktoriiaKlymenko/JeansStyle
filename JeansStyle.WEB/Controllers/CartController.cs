using AutoMapper;
using JeansStyle.BLL.Interfaces;
using JeansStyle.WEB.Models;
using JeansStyle.WEB.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace JeansStyle.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly IProductSizeService _productSizeService;
        private readonly IMapper _mapper;
        public CartController(ISearchService searchService, IMapper mapper, IProductSizeService productSizeService)
        {

            _searchService = searchService;
            _mapper = mapper;
            _productSizeService = productSizeService;

        }

        [HttpPost]
        public async Task<string> GetData(List<Cart> carts)
        {

            var productSizes = new List<ProductSize>();
            var model = new List<CartApiModel>();
            foreach (var cart in carts)
            {
               var productSize = _mapper.Map<ProductSize>(await _productSizeService.GetProductSizeById(cart.ProductSizeId));
                var product = _mapper.Map<Product>(await _searchService.GetProductById(cart.ProductId));
                var cartModel = new CartApiModel()
                {

                    Product = productSize.Product == null ? product : productSize.Product,
                    ProductSize = productSize,
                    Amount = cart.Amount,
                    TotalPrice = cart.Amount * productSize.Product.Price
                };
                model.Add(cartModel);

            }
                

            var modelSerialized = JsonSerializer.Serialize(model);

            return modelSerialized;
        }


    }
}

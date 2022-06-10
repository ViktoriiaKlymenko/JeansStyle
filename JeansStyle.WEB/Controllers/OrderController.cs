using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansStyle.WEB.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ISearchService _searchService;
        private readonly IProductSizeService _productSizeService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, ISearchService searchService, IMapper mapper, IProductSizeService productSizeService)
        {
            _orderService = orderService;
            _searchService = searchService;
            _mapper = mapper;
            _productSizeService = productSizeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Create(List<Cart> carts)
        {
            var orderDto = new OrderDto
            {
                ProductSizes = new List<ProductSizeDto>(),
                Products = new List<ProductDto>(),
            };

            foreach (var cart in carts)
            {
                var productSizes = _mapper.Map<Product>(await _productSizeService.GetProductSizeById(cart.ProductSizeId));
                var product = _mapper.Map<Product>(await _searchService.GetProductById(cart.ProductId));
              
            }
           
           
            return View("ContactCustomer");
        }

        public ActionResult Complete(List<ProductSize> productSizes, UserCredentialsViewModel model)
        {
            var products =_mapper.Map<List<ProductSizeDto>>(productSizes);
            var order = new OrderDto();
            //order.Products = products;
            order.UserCredentials.FirstName = model.FirstName;
            order.UserCredentials.MiddleName = model.MiddleName;
            order.UserCredentials.LastName = model.LastName;
            order.UserCredentials.Address = model.Address;
            order.UserCredentials.PhoneNumber = model.PhoneNumber;
            decimal totalPrice = 0;
            foreach (var product in products)
            {
                totalPrice += product.Product.Price * product.Amount;
            }
            order.TotalPrice = totalPrice;
            _orderService.Create(order);
            return RedirectToAction("ContactCustomer");
        }

        public ActionResult GetOrders()
        {
            var orders = _orderService.GetAll();

            ViewBag.Orders = orders;
            return View();
        }

        public ActionResult ContactCustomer()
        {
            return View();
        }

    }
}

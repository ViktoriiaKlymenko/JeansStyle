using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace JeansStyle.WEB.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Complete(ProductSize productSizes, UserCredentialsViewModel model)
        {
            var products =_mapper.Map<List<ProductSizeDto>>(productSizes);
            var order = new OrderDto();
            order.Products = products;
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

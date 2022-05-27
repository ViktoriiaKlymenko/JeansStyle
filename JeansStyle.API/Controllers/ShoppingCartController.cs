using JeansStyle.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using RestSharp;

namespace JeansStyle.API.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(Product product, string returnUrl)
        {
            return Redirect(returnUrl);
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}

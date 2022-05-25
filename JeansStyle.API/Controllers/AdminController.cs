using AutoMapper;
using JeansStyle.API.Models;
using JeansStyle.API.Models.Enums;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.API.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(ISearchService searchService, IAdminService adminService, IMapper mapper)
        {
            _searchService = searchService;
            _adminService = adminService;
            _mapper = mapper;
        }

        public ActionResult Delete(Guid id)
        {           
            var product = _searchService.GetById(id);
            _adminService.DeleteProduct(product);
            return View();
        }

        public ActionResult GetProducts()
        {
            ViewBag.Products =  _searchService.GetAll().Products;
            return View();
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            var product = new Product();

            return View(product);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string filePath = "wwwroot/images/clothes/" + product.Image.FileName;
                    using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
                    {
                        await product.Image.CopyToAsync(fileStream);
                    }                  

                    var productDto = _mapper.Map<ProductDto>(product);
                    productDto.Image = filePath;

                    _adminService.AddProduct(productDto);
                    return RedirectToAction("GetProducts");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(product);
        }
    }
}

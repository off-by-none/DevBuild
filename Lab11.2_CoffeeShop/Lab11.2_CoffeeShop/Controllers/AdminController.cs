using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab11._3_CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Lab11._3_CoffeeShop.Controllers
{
    public class AdminController : Controller
    {
        IConfiguration ConfigRoot;
        DAL dal;

        public AdminController(IConfiguration config)
        {
            ConfigRoot = config;
            dal = new DAL(ConfigRoot.GetConnectionString("coffeeDB"));
        }

        public IActionResult Index()
        {
            ViewData["Products"] = dal.GetProductsAll();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            int result = dal.CreateProduct(product);

            if (result == 1)
            {
                TempData["UserMsg"] = "Item successfully added";
            }
            else
            {
                TempData["UserMsg"] = "Item not added";
            }

            return RedirectToAction("Index");
        }

        public IActionResult AddForm()
        {
            Product product = new Product();

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            int result = dal.DeleteProductById(id);

            if (result == 1)
            {
                TempData["UserMsg"] = "Item successfully deleted";
            }
            else
            {
                TempData["UserMsg"] = "Item for deletion not found";
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = dal.GetProductById(id);

            if (product == null)
            {
                return View("NoSuchItem");
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            int result = dal.UpdateProductById(product);

            if (result == 1)
            {
                TempData["UserMsg"] = "Item successfully updated";
            }
            else
            {
                TempData["UserMsg"] = "Item not updated";
            }

            return RedirectToAction("Index");
        }
    }
}
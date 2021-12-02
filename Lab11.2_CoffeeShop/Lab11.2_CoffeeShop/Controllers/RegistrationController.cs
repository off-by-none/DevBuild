using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab11._3_CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab11._3_CoffeeShop.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("RegistrationIndex");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                return View(register);
            }
            else
            {
                ViewData["errorMsg"] = "Your form had errors. Please correct and re-submit.";
                return View("RegistrationIndex", register);
            }
        }
    }
}
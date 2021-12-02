using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab161_ClientSideValidation.Models;

namespace Lab161_ClientSideValidation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult User()
        {
            //User p = new User();
            //return View(p);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult User(User u)
        {
            //validate server-side (back-end)
            // can use data annotations etc in the model class
            // this is our final and safest check on the data

            //the client-side validation tries to limit unnecessary server load
            // and the time the user has to wait for response

            //put info into the database here etc

            return View("UserSuccess", u);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

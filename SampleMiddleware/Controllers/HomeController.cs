using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleMiddleware.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            return View();
        }

        public IActionResult Error()
        {
            throw new Exception("Error");
        }
    }
}
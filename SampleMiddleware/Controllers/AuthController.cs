using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleMiddleware.Models;

namespace SampleMiddleware.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            HttpContext.Session.SetString("Name", model.Name);
            return RedirectToAction("Index", "Home");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System;

namespace SistemaWebMisRecetas.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Bienvenida = "Bienvenida a la página de sus recetas!";
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitStore6.Models;
using Microsoft.AspNetCore.Mvc;

namespace FruitStore6.Areas.Administrador.Controllers
{
    public class HomeController : Controller
    {
       
        [Area("Administrador")]
        public IActionResult Index()
        {
            return View();
        }


    }
}
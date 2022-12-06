using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitStore6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FruitStore6.Areas.Administrador.Controllers
{
    [Authorize]
    [Area("Administrador")]
    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }


    }
}
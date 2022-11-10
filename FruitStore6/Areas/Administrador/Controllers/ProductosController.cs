using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FruitStore6.Areas.Administrador.Controllers
{
    public class ProductosController : Controller
    {
        [Area("Administrador")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Agregar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Eliminar()
        {
            return View();
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitStore6.Models;
using FruitStore6.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FruitStore.Controllers
{
    public class HomeController : Controller
    {
        fruteriashopContext context;
        public HomeController(fruteriashopContext context)
        {
            this.context = context;
        }

        [Route("/")]
        [Route("/home")]
        [Route("/principal")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/c/{id}")]
        public IActionResult Categoria(string id)
        {
            var datos = context.Categorias.Include(x => x.Productos).Where(x => x.Nombre == id).Select(x => new CategoriaViewModel
            {
                NombreCategoria = x.Nombre,
                Producto = x.Productos.Select(x => new Producto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Precio = x.Precio
                })
            }).FirstOrDefault();
            return View(datos);
        }

        [Route("/p/{nombre}")]
        public IActionResult Ver(string? nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return RedirectToAction(nameof(Index));
            }
            nombre = nombre.Replace("-", " ");
            var producto = context.Productos.Include(x=>x.IdCategoriaNavigation).FirstOrDefault(x => x.Nombre == nombre);
            if (producto == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(producto);
            }
        }
    }
}
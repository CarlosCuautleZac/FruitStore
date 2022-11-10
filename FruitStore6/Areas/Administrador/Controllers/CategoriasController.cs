using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitStore6.Models;
using Microsoft.AspNetCore.Mvc;

namespace FruitStore6.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class CategoriasController : Controller
    {
        fruteriashopContext _context;

        public CategoriasController(fruteriashopContext context)
        {
            _context = context;
        }


        
        public IActionResult Index()
        {
            var categirias = _context.Categorias.Where(x => x.Eliminado == false).OrderBy(x => x.Nombre);

            return View(categirias);
        }

        
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Categoria c)
        {
            if (string.IsNullOrWhiteSpace(c.Nombre))
            {
                ModelState.AddModelError("", "Debe escribir el nombre de la categoria");
            }

            if (_context.Categorias.Any(x => x.Nombre == c.Nombre))
            {
                ModelState.AddModelError("", "Ya existe una categoria con ese nombre");
            }

            if (ModelState.IsValid)
            {
                _context.Add(c);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(c);
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
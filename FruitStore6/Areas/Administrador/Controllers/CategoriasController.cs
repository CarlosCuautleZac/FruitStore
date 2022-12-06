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

        public IActionResult Editar(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null)
                return RedirectToAction("Index");

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Editar(Categoria c)
        {
            //Validar 
            if (string.IsNullOrWhiteSpace(c.Nombre))
            {
                ModelState.AddModelError("", "Debe escribir el nombre de la categoria");
            }
            //Validar que no se repita otro y que no sea yo
            if (_context.Categorias.Any(x => x.Nombre == c.Nombre && x.Id != c.Id))
            {
                ModelState.AddModelError("", "Ya existe una categoria con ese nombre");
            }

            if (ModelState.IsValid)
            {
                var categoria = _context.Categorias.Find(c.Id);

                if (categoria == null)
                    return RedirectToAction("Index");

                categoria.Nombre = c.Nombre;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(c);




            //else
            //    return View(c);



        }

        public IActionResult Eliminar(int id)
        {
            var categoria = _context.Categorias.Find(id);

            if (categoria == null)
                return RedirectToAction("Index");

            return View(categoria);

        }

        [HttpPost]
        public IActionResult Eliminar(Categoria c)
        {
            var categoria = _context.Categorias.Find(c.Id);
            if (categoria == null)
            {
                ModelState.AddModelError("", "La categoria no existe o ya ha sido eliminada");
            }

            else
            {

                if (_context.Productos.Any(x => x.IdCategoria == c.Id))
                {
                    ModelState.AddModelError("", "No se puede eliminar una categoria que tenga productos");
                }

                if (ModelState.IsValid)
                {
                    _context.Remove(categoria);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(categoria);


        }
    }
}
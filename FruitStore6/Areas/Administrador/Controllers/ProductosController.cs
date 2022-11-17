using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitStore6.Areas.Administrador.Models;
using FruitStore6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FruitStore6.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class ProductosController : Controller
    {
        private readonly fruteriashopContext context;

        public ProductosController(fruteriashopContext context)
        {
            this.context = context;
        }

        public IActionResult Index(IndexProductosViewModel vm)
        {


            if (vm.IdCategoria == 0)//No eligieron categoria, selecciono todo
            {
                vm.Productos = context.Productos.Include(x=>x.IdCategoriaNavigation).OrderBy(x => x.Nombre);
            }
            else
            {
                vm.Productos = context.Productos.Where(x => x.IdCategoria == vm.IdCategoria).Include(x=>x.IdCategoriaNavigation).OrderBy(x=>x.Nombre);
            }

            vm.Categorias = context.Categorias.OrderBy(x => x.Nombre);

            return View(vm);
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
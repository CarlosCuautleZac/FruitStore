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
        private readonly IWebHostEnvironment env;

        public ProductosController(fruteriashopContext context, IWebHostEnvironment env)
        {
           
            this.context = context;
            this.env = env;
        }

        public IActionResult Index(IndexProductosViewModel vm)
        {


            if (vm.IdCategoria == 0)//No eligieron categoria, selecciono todo
            {
                vm.Productos = context.Productos.Include(x => x.IdCategoriaNavigation).OrderBy(x => x.Nombre);
            }
            else
            {
                vm.Productos = context.Productos.Where(x => x.IdCategoria == vm.IdCategoria).Include(x => x.IdCategoriaNavigation).OrderBy(x => x.Nombre);
            }

            vm.Categorias = context.Categorias.OrderBy(x => x.Nombre);

            return View(vm);
        }


        public IActionResult Agregar()
        {
            ProductosViewModel vm = new();
            vm.Categorias = context.Categorias.OrderBy(x => x.Nombre);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Agregar(ProductosViewModel vm)
        {
            //Validar
            if (vm.Producto != null)
            {
                if (string.IsNullOrWhiteSpace(vm.Producto.Nombre))
                {
                    ModelState.AddModelError("", "Escriba el nombre del producto");
                }

                //Si todo sale bien va a la base de datos
                if (ModelState.IsValid)
                {
                    context.Add(vm.Producto);
                    context.SaveChanges();

                    if (vm.Imagen == null)//El usuario no elegio imagen
                    {
                        string nodisp = env.WebRootPath+"/img_frutas/no-disponible.png";
                        string nuevaruta = env.WebRootPath + $"/img_frutas/{vm.Producto.Id}.jpg";

                        System.IO.File.Copy(nodisp, nuevaruta);
                    }
                    else
                    {
                        string nuevaruta = env.WebRootPath + $"/img_frutas/{vm.Producto.Id}.jpg";
                        var archivo = System.IO.File.Create(nuevaruta);
                        vm.Imagen.CopyTo(archivo);
                        archivo.Close();
                    }
                    return RedirectToAction("Index");
                }
            }

            vm.Categorias = context.Categorias.OrderBy(x => x.Nombre);
            return View(vm);
        }


        public IActionResult Editar(int id)
        {
            var p = context.Productos.Find(id);

            if (p == null)
                RedirectToAction("Index");

            ProductosViewModel vm = new ProductosViewModel();
            vm.Producto = p;
            vm.Categorias = context.Categorias.OrderBy(x => x.Nombre);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Editar(ProductosViewModel vm)
        {
            if (vm.Producto != null)
            {
                var producto = context.Productos.Find(vm.Producto.Id);
                if (producto == null)
                {
                    return RedirectToAction("Index");
                }

                //Validar
                if(string.IsNullOrWhiteSpace(vm.Producto.Nombre))
                {
                    ModelState.AddModelError("", "Escriba el nombre del producto");
                }

                if (ModelState.IsValid)
                {
                    producto.Nombre = vm.Producto.Nombre;
                    producto.Descripcion=vm.Producto.Descripcion;
                    producto.UnidadMedida = vm.Producto.UnidadMedida;
                    producto.Precio=vm.Producto.Precio;
                    producto.IdCategoria=vm.Producto.IdCategoria;
                    context.SaveChanges();
                }
            }

            return View();
        }

        public IActionResult Eliminar()
        {
            return View();
        }
    }

}
using FruitStore6.Models;

namespace FruitStore6.Areas.Administrador.Models
{
    public class ProductosViewModel
    {
        public Producto? Producto { get; set; }
        public IEnumerable<Categoria>? Categorias { get; set; }
        public IFormFile? Imagen { get; set; }
    }
}

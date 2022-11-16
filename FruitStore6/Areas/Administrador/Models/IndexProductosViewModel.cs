using FruitStore6.Models;

namespace FruitStore6.Areas.Administrador.Models
{
    public class IndexProductosViewModel
    {
        public IEnumerable<Categoria>? Categorias { get; set; }
        public IEnumerable<Producto>? Productos { get; set; }
        public int IdCategoria { get; set; }
    }
}

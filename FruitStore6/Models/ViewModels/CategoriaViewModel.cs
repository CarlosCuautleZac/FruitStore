namespace FruitStore6.Models.ViewModels
{
    public class CategoriaViewModel
    {
        public string? NombreCategoria { get; set; } = "";
        public IEnumerable<Producto>? Producto { get; set; }
    }
}

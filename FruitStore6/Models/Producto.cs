using System;
using System.Collections.Generic;

namespace FruitStore6.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? IdCategoria { get; set; }
        public decimal? Precio { get; set; }
        public string? UnidadMedida { get; set; }
        public string? Descripcion { get; set; }

        public virtual Categoria? IdCategoriaNavigation { get; set; }
    }
}

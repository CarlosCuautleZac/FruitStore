using FruitStore6.Models;

namespace FruitStore6.Services
{
    public class MenuService
    {
        fruteriashopContext cx;
        //Inyeccion de dependencias
        public MenuService(fruteriashopContext context)
        {
            cx = context;
        }

        public IEnumerable<Categoria> Get()
        {
            return cx.Categorias.Where(x=>x.Eliminado == false).OrderBy(c => c.Nombre);
        }









    }
}

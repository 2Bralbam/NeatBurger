using Microsoft.EntityFrameworkCore;
using NeatBurger.Areas.Admin.Models.Entities;
using NeatBurger.Models.Entities;
using NeatBurger.Models.MyEntities;

namespace NeatBurger.Repositories
{
    public class MenuRepository:GenericRepository<Menu>
    {
        private readonly NeatContext _context;
        public MenuRepository(NeatContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<Menu> GetMenusByIdClasif(int Id)
        {
            return _context.Menu.Where(x => x.IdClasificacionNavigation.Id == Id).AsEnumerable();
        }
        public Menu? GeById(int Id)
        {
            return _context.Menu.Include(x=>x.IdClasificacionNavigation).FirstOrDefault(x => x.Id == Id);
        }
        public FoodMenuDisplayModel? GetMenuByName(string Nombre)
        {
            return _context.Menu.Where(x => x.Nombre == Nombre).Select(x => new FoodMenuDisplayModel
            {
                Descripción = x.Descripción,
                Id = x.Id,
                Nombre = x.Nombre,
                Precio = x.Precio
            }).FirstOrDefault();
        }
        public FoodMenuDisplayModel? GetDisplayMenu(int Id)
        {
            return _context.Menu.Where(x => x.Id == Id).Select(x => new FoodMenuDisplayModel
            {
                Nombre = x.Nombre,
                Precio = x.Precio,
                Id = x.Id,
                Descripción = x.Descripción
            }).FirstOrDefault();
        }
        public List<MenusByCategorias> GetCategoriasMenus()
        {
            List<MenusByCategorias> l = new();
            IEnumerable<Clasificacion> c = _context.Clasificacion.Include(x=>x.Menu);
            foreach (var cat in c) 
            {
                l.Add(new MenusByCategorias 
                {
                    Menus = cat.Menu.Select(x=> new MenuModel 
                    {
                        Descripcion = x.Descripción,
                        Id = x.Id,
                        Nombre = x.Nombre,
                        Precio = (decimal)x.Precio,
                        PrecioPromocion = (decimal)(x.PrecioPromocion ?? 0)
                    }),
                    NombreCategoria = cat.Nombre
                });
            }
            return l;
        }
    }
}

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
    }
}

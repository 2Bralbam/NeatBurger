using NeatBurger.Areas.Admin.Models.Entities;
using NeatBurger.Models.Entities;

namespace NeatBurger.Repositories
{
    public class ClasificacionesRepository:GenericRepository<Clasificacion>
    {
        private readonly NeatContext _context;
        public ClasificacionesRepository(NeatContext context):base(context)
        {
            _context = context;
        }
        public IEnumerable<ClasificacionesModel> GetClasificaciones()
        {
            return _context.Clasificacion.Select(c => new ClasificacionesModel
            {
                Id = c.Id,
                Nombre = c.Nombre
            });
        }
    }
}

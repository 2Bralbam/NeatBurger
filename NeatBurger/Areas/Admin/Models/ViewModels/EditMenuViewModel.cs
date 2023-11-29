using NeatBurger.Areas.Admin.Models.Entities;
using NeatBurger.Models.Entities;

namespace NeatBurger.Areas.Admin.Models.ViewModels
{
    public class EditMenuViewModel
    {
        public int IdClasificacion { get; set; }
        public IEnumerable<ClasificacionesModel> Clasificaciones { get; set; } = null!;
        public Menu EditModel { get; set; } = null!;
        public IFormFile? formFile { get; set; } = null!;
    }
}

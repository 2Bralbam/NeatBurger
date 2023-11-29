using NeatBurger.Areas.Admin.Models.Entities;

namespace NeatBurger.Areas.Admin.Models.ViewModels
{
    public class AdminMenuViewModel
    {
        public IEnumerable<MenusByCategorias> MenuList { get; set; } = null!;
    }
}

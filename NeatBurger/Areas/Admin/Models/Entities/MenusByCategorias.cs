namespace NeatBurger.Areas.Admin.Models.Entities
{
    public class MenusByCategorias
    {
        public string NombreCategoria { get; set; } = null!;
        public IEnumerable<MenuModel> Menus { get; set; } = null!;
    }
}

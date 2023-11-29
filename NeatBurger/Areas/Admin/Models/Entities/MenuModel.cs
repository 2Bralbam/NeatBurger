namespace NeatBurger.Areas.Admin.Models.Entities
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public decimal PrecioPromocion { get; set; }
    }
}

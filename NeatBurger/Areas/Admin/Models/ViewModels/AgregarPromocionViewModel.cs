namespace NeatBurger.Areas.Admin.Models.ViewModels
{
    public class AgregarPromocionViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public decimal PrecioPromocion { get; set; }
    }
}

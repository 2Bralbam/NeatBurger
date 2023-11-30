namespace NeatBurger.Models.MyEntities
{
    public class PromocionModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public decimal PrecioPromocio { get; set; }
    }
}

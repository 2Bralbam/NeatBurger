namespace NeatBurger.Models.MyEntities
{
    public class FoodMenuModel
    {
        public string Nombre { get; set; } = null!;
        public double Precio { get; set; } = 0;
        public int ProductId { get; set; } = 0;
        public string Descripción { get; set; } = null!;
    }
}

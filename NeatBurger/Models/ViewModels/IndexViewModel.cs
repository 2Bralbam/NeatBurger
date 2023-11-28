using NeatBurger.Models.MyEntities;

namespace NeatBurger.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<FoodMenuModel> MenuList { get; set; } = null!;
        public List<FoodMenuModel> ChefFavList { get; set; } = null!;
        public int SelectedProduct { get; set; } = 0;
        
    }
}

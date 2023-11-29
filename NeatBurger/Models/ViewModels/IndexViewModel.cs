using NeatBurger.Models.MyEntities;

namespace NeatBurger.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<FoodMenuModel> MenuList { get; set; } = null!;
        public IEnumerable<FoodMenuModel> ChefFavList { get; set; } = null!;
        public IEnumerable<FoodMenuModel> TendenciaList { get; set; } = null!;
        public FoodMenuDisplayModel? DisplayMenu {get;set;} = null!;
        
    }
}

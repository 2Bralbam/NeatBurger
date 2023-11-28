using Microsoft.AspNetCore.Mvc;
using NeatBurger.Models.Entities;
using NeatBurger.Models.MyEntities;
using NeatBurger.Models.ViewModels;
using NeatBurger.Repositories;

namespace NeatBurger.Controllers
{
    public class MenuController : Controller
    {
        private readonly GenericRepository<Menu> _menuRepository;
        public MenuController(GenericRepository<Menu> genericMRepository)
        {
            _menuRepository = genericMRepository;
        }
        public IActionResult Index()
        {
            List<FoodMenuModel> menuList = _menuRepository.GetAll().Select(x => new FoodMenuModel
            {
                Nombre = x.Nombre,
                Precio = x.Precio,
                Descripción = x.Descripción,
                ProductId = x.Id
            }).ToList();
            List<FoodMenuModel> chefFavMenu = menuList.Take(3).ToList();
            menuList.RemoveRange(0, 3);

            IndexViewModel indexViewModel = new IndexViewModel
            {
                MenuList = menuList,
                ChefFavList = chefFavMenu
            };
            return View(indexViewModel);
        }
        [Route("/Menu/{Id}")]
        public IActionResult Index(string Id)
        {
            List<FoodMenuModel> menuList = _menuRepository.GetAll().Select(x => new FoodMenuModel
            {
                Nombre = x.Nombre,
                Precio = x.Precio,
                Descripción = x.Descripción,
                ProductId = x.Id
            }).ToList();
            List<FoodMenuModel> chefFavMenu = menuList.Take(3).ToList();
            menuList.RemoveRange(0, 3);

            IndexViewModel indexViewModel = new IndexViewModel
            {
                MenuList = menuList,
                ChefFavList = chefFavMenu,
                SelectedProduct = (menuList.Where(x=>x.Nombre == Id.Replace("-"," ")).Select(x=>x.ProductId)).First()
            };
            return View(indexViewModel);
        }
    }
}

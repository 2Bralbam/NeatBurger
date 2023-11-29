using Microsoft.AspNetCore.Mvc;
using NeatBurger.Models.Entities;
using NeatBurger.Models.MyEntities;
using NeatBurger.Models.ViewModels;
using NeatBurger.Repositories;

namespace NeatBurger.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuRepository _menuRepository;
        public MenuController(MenuRepository genericMRepository)
        {
            _menuRepository = genericMRepository;
        }
        public IActionResult Index()
        {
            int Id = 1;
            IndexViewModel vm = new()
            {
                MenuList = _menuRepository.GetMenusByIdClasif(2).Select(x => new FoodMenuModel
                {
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    Id = x.Id,
                    Seleccionado = x.Id == Id ? true : false
                }).ToList(),
                ChefFavList = _menuRepository.GetMenusByIdClasif(3).Select(x => new FoodMenuModel
                {
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    Id = x.Id,
                    Seleccionado = x.Id == Id ? true : false
                }).ToList(),
                TendenciaList = _menuRepository.GetMenusByIdClasif(1).Select(x => new FoodMenuModel
                {
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    Id = x.Id,
                    Seleccionado = x.Id == Id ? true : false
                }).ToList(),
                DisplayMenu = _menuRepository.GetDisplayMenu(Id)
            };
            return View(vm);
        }
        [Route("/Menu/{Id}")]
        public IActionResult Index(string Id)
        {
            int Ids = 1;
            if (!string.IsNullOrEmpty(Id)) 
            {
                FoodMenuDisplayModel? menuSeleccionado = _menuRepository.GetMenuByName(Id.Replace("-", " "));
                if (menuSeleccionado != null) 
                {
                    Ids = menuSeleccionado.Id;
                }
            }
            IndexViewModel vm = new()
            {
                MenuList = _menuRepository.GetMenusByIdClasif(2).Select(x => new FoodMenuModel
                {
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    Id = x.Id,
                    Seleccionado = x.Id == Ids ? true : false
                }).ToList(),
                ChefFavList = _menuRepository.GetMenusByIdClasif(3).Select(x => new FoodMenuModel
                {
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    Id = x.Id,
                    Seleccionado = x.Id == Ids ? true : false
                }).ToList(),
                TendenciaList = _menuRepository.GetMenusByIdClasif(1).Select(x => new FoodMenuModel
                {
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    Id = x.Id,
                    Seleccionado = x.Id == Ids ? true : false
                }).ToList(),
                DisplayMenu = _menuRepository.GetDisplayMenu(Ids)
            };
            return View(vm);
        }
    }
}

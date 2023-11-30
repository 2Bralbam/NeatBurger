using Microsoft.AspNetCore.Mvc;
using NeatBurger.Models.Entities;
using NeatBurger.Models.ViewModels;
using NeatBurger.Repositories;

namespace NeatBurger.Controllers
{
    public class PromocionesController : Controller
    { 
        private readonly MenuRepository _menuRepository;
        public PromocionesController(MenuRepository menuRepository)
        {

            _menuRepository = menuRepository;

        }
        public IActionResult Index(string Id)
        {
            if (Id == null)
            {
                Id = _menuRepository.GetAllMenusWithPromo().FirstOrDefault().Nombre;
            }

            if (Id != null)
            {
                Id = Id.Replace("-", " ");
                Menu PromocionMenu = _menuRepository.GetMenuPromByName(Id);
                PromocionesViewModel vm = new();
                vm.Promocion = new();
                vm.Promocion.Nombre = PromocionMenu.Nombre;
                vm.Promocion.Descripcion = PromocionMenu.Descripción;
                vm.Promocion.PrecioPromocio = (decimal)PromocionMenu.PrecioPromocion;
                vm.Promocion.Precio = (decimal)PromocionMenu.Precio;
                vm.Promocion.Id = PromocionMenu.Id;
                vm.PromocionAnterior = "AAs";
                vm.PromocionSiguiente = "AS";

                return View(vm);

            }
            else 
            {
                return View();
            }

        }
    }
}

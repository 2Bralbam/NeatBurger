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
        [Route("Promociones/{Id?}")]
        public IActionResult Index(string Id)
        {
            if (Id == null)
            {
                Menu m = _menuRepository.GetAllMenusWithPromo().OrderBy(x=>x.Id).FirstOrDefault();
                Id = m.Nombre;
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
                var promAnterior = _menuRepository.GetAllMenusWithPromo().OrderByDescending(x=>x.Id).Where(x=>x.Id < PromocionMenu.Id).FirstOrDefault();
                var promSiguiente = _menuRepository.GetAllMenusWithPromo().OrderBy(x=>x.Id).Where(x=>x.Id > PromocionMenu.Id).FirstOrDefault();
                //vm.PromocionAnterior = _menuRepository.GetAllMenusWithPromo().OrderByDescending(x=>x.Id).Where(x=>x.Id < PromocionMenu.Id).FirstOrDefault().Nombre;
                //vm.PromocionSiguiente = "AS";
                if (promAnterior != null)
                {
                    vm.PromocionAnterior = promAnterior.Nombre.Replace(" ", "-");
                }
                else 
                {
                    vm.PromocionAnterior = PromocionMenu.Nombre.Replace(" ","-");
                }
                if (promSiguiente != null)
                {
                    vm.PromocionSiguiente = promSiguiente.Nombre.Replace(" ", "-");
                }
                else 
                {
                    vm.PromocionSiguiente = PromocionMenu.Nombre.Replace(" ", "-");
                }
                return View(vm);

            }
            else 
            {
                return View();
            }

        }
    }
}

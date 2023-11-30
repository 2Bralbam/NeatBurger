using Microsoft.AspNetCore.Mvc;
using NeatBurger.Areas.Admin.Models.Entities;
using NeatBurger.Areas.Admin.Models.ViewModels;
using NeatBurger.Models.Entities;
using NeatBurger.Repositories;

namespace NeatBurger.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly MenuRepository _menuRepository;
        private readonly ClasificacionesRepository _clasificacionesRepository;
        public MenuController(MenuRepository repositoryM, ClasificacionesRepository clasificacionesRepository)
        {
            _menuRepository = repositoryM;
            _clasificacionesRepository = clasificacionesRepository;

        }
        public IActionResult Index()
        {
            AdminMenuViewModel vm = new()
            {
                MenuList = _menuRepository.GetCategoriasMenus()
            };
            return View(vm);
        }
        [Route("Admin/Editar-Menu/{Id}")]
        public IActionResult Editar(int Id)
        {
            Menu? M = _menuRepository.GeById(Id);
            if(M is null)
            {
                return RedirectToAction("Index");
            }
            EditMenuViewModel vm = new() 
            { 
                Clasificaciones = _clasificacionesRepository.GetClasificaciones(),
                EditModel = _menuRepository.GeById(Id),
                IdClasificacion = M.Id
            };
            return View(vm);
        }
        [Route("Admin/Editar-Menu/{Id}")]
        [HttpPost]
        public IActionResult Editar(Menu m)
        {
            if (string.IsNullOrEmpty(m.Descripción))
            {
                return RedirectToAction("Index");
            }
            if (string.IsNullOrEmpty(m.Nombre))
            {
                return RedirectToAction("Index");
            }
            if (m.Precio ==0)
            {
                return RedirectToAction("Index");
            }
            Menu? M = _menuRepository.GeById(m.Id);

            if (M is null)
            {
                return RedirectToAction("Index");
            }
            M.Nombre = m.Nombre;
            M.Descripción = m.Descripción;
            M.Precio = m.Precio;

            _menuRepository.Update(M);
            return View(m);
        }
        public IActionResult Agregar() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Agregar(EditModel Menu) 
        {
            if (string.IsNullOrEmpty(Menu.Descripcion))
            {
                return RedirectToAction("Index");
            }
            if (string.IsNullOrEmpty(Menu.Nombre))
            {
                return RedirectToAction("Index");
            }
            if (Menu.Precio == 0)
            {
                return RedirectToAction("Index");
            }
            Menu M = new()
            {
                Nombre = Menu.Nombre,
                Descripción = Menu.Descripcion,
                Precio = (double)Menu.Precio,
                IdClasificacion = Menu.ClasificacionId,
                Id = 0
            };
            _menuRepository.Insert(M);
            return View(M);
        }
    }
}

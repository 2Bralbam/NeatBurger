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
        [HttpPost]
        public IActionResult Editar(EditMenuViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.EditModel.Descripción))
            {
                ModelState.AddModelError("Descripción", "La descripción no puede estar vacia");
                return RedirectToAction("Index");
            }
            if (string.IsNullOrEmpty(vm.EditModel.Nombre))
            {
                ModelState.AddModelError("Nombre", "El nombre no puede estar vacio");
                return RedirectToAction("Index");
            }
            if (vm.EditModel.Precio ==0)
            {
                ModelState.AddModelError("Precio", "El precio no puede ser 0");
                return RedirectToAction("Index");
            }
            Menu? M = _menuRepository.GeById(vm.EditModel.Id);
            if (vm.formFile != null)
            {

                if (vm.formFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("formFile", "El archivo debe ser de tipo jpeg");
                    return RedirectToAction("Index");
                }
                if (vm.formFile.Length > (500 * 1024))
                {
                    ModelState.AddModelError("formFile", "El archivo no puede ser mayor a 500kb");
                    return RedirectToAction("Index");
                }
            }
            else 
            {

            }
            if (M is null)
            {
                return RedirectToAction("Index");
            }
                M.Nombre = vm.EditModel.Nombre;
                M.Descripción = vm.EditModel.Descripción;
                M.Precio = vm.EditModel.Precio;

                _menuRepository.Update(M);
                if (vm.formFile == null)
                {
                    System.IO.File.Copy($"wwwroot/images/burger.png", $"wwwroot/hamburguesas/{M.Id}.jpeg");
                }
                else 
                {
                    System.IO.FileStream fs = System.IO.File.Create($"wwwroot/hamburguesas/{M.Id}.jpeg");
                    vm.formFile.CopyTo(fs);
                    fs.Close();
                }
            return RedirectToAction("Index");
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
        [Route("Admin/Eliminar/{Id}")]
        public IActionResult Eliminar(int Id) 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(Menu M)
        {
            Menu? m = _menuRepository.GeById(M.Id);
            if (m == null)
            {
                return RedirectToAction("Index");
            }
            else 
            {
                _menuRepository.Delete(m);
            }
            return RedirectToAction("Index");
        }
    }
}

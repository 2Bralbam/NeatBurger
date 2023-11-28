using Microsoft.AspNetCore.Mvc;

namespace NeatBurger.Controllers
{
    public class PromocionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

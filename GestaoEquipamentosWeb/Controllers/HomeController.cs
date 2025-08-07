
using Microsoft.AspNetCore.Mvc;

namespace GestaoEquipamentosWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Vai renderizar Views/Home/Index.cshtml
        }

        public IActionResult Privacy()
        {
            return View(); // Vai renderizar Views/Home/Privacy.cshtml
        }
    }
}
